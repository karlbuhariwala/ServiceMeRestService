﻿// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetProfileCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using RestServiceV1.Providers;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Command to get the profile of the user
    /// </summary>
    public class GetProfileCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetProfileRequestContainer requestContainer = context.InParam as GetProfileRequestContainer;
            GetProfileReturnContrainer returnContainer = new GetProfileReturnContrainer();

            // Todo: Optimize after writing query
            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@userId", requestContainer.UserId }, { "@deleted", false } };
            DataSet returnedData = sqlProvider.ExecuteQuery(SqlQueries.GetUserProfileQuery, parameters);
            if (returnedData.Tables[0].Rows.Count == 1)
            {
                DataRow row = returnedData.Tables[0].Rows[0];
                UserProfile userProfile = new UserProfile();
                userProfile.Name = row["Name"].ToString();
                userProfile.PhoneNumber = row["PhoneNumber"].ToString();
                bool tempBool;
                if (bool.TryParse(row["IsVerified"].ToString(), out tempBool))
                {
                    userProfile.IsVerified = tempBool;
                }
                else
                {
                    // Todo: Log
                }

                userProfile.ContactPreference = row["ContactPref"].ToString().Split(new string[] { Constants.QuerySeparator }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                userProfile.EmailAddress = row["EmailAddress"].ToString();
                userProfile.Address = row["Address"].ToString();
                if (bool.TryParse(row["IsAgent"].ToString(), out tempBool))
                {
                    userProfile.IsAgent = tempBool;
                }
                else
                {
                    // Todo: Log
                }

                if (bool.TryParse(row["IsManager"].ToString(), out tempBool))
                {
                    userProfile.IsManager = tempBool;
                }
                else
                {
                    // Todo: Log
                }
                userProfile.LandingPage = row["LandingPage"].ToString();
                userProfile.PushNotificationUri = row["PushNotificationsUri"].ToString();
                double tempDouble;
                if (double.TryParse(row["Rating"].ToString(), out tempDouble))
                {
                    userProfile.Rating = tempDouble;
                }

                int tempInt;
                if (int.TryParse(row["NumberOfRatings"].ToString(), out tempInt))
                {
                    userProfile.NumberOfRatings = tempInt;
                }

                userProfile.Tags = row["Tags"].ToString().Split(new string[] { Constants.QuerySeparator }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                userProfile.AreaOfService = row["AreaOfService"].ToString();
                userProfile.FavoriteAgents = row["FavoriteAgents"].ToString().Split(new string[] { Constants.QuerySeparator }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

                // Found user and returning it
                returnContainer.ReturnCode = ReturnCodes.C101;
                returnContainer.User = userProfile;
            }
            else
            {
                // User does not exist
                returnContainer.ReturnCode = ReturnCodes.C001;
            }

            return returnContainer;
        }
    }
}