// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = UpdateUserProfileCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using RestServiceV1.Providers;
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Command to update the user profile of the user
    /// </summary>
    public class UpdateUserProfileCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            UpdateProfileRequestContainer requestContainer = context.InParam as UpdateProfileRequestContainer;
            UpdateProfileReturnContainer returnContainer = new UpdateProfileReturnContainer();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@UserInfoName", requestContainer.UserProfile.Name);
            parameters.Add("@UserInfoContactPref", string.Join(Constants.QuerySeparator, requestContainer.UserProfile.ContactPreference));
            parameters.Add("@UserInfoEmailAddress", requestContainer.UserProfile.EmailAddress);
            parameters.Add("@UserInfoAddress", requestContainer.UserProfile.Address);
            parameters.Add("@IsAgent", requestContainer.UserProfile.IsAgent);
            parameters.Add("@IsManager", requestContainer.UserProfile.IsManager);
            parameters.Add("@LandingPage", requestContainer.UserProfile.LandingPage);
            parameters.Add("@userId", requestContainer.UserProfile.UserId);
            sqlProvider.ExecuteQuery(SqlQueries.UpdateUserProfile, parameters);

            returnContainer.IsAgent = requestContainer.UserProfile.IsAgent;
            returnContainer.ReturnCode = ReturnCodes.C101;

            return returnContainer;
        }
    }
}