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
    using System.Web.Script.Serialization;
    using DataContracts.InApp;
    /// <summary>
    /// Command to update the user profile of the user
    /// </summary>s
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

            IGeolocationProvider geolocationProvider = (IGeolocationProvider)ProviderFactory.Instance.CreateProvider<IGeolocationProvider>(null);
            Coordinates coordinates = geolocationProvider.GetCoordinates(requestContainer.UserProfile.Address);
            if(coordinates.Latitude == 0 || coordinates.Longitude == 0)
            {
                returnContainer.ReturnCode = ReturnCodes.C001;
                return returnContainer;
            }

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parametersForProfile = new Dictionary<string, object>();
            parametersForProfile.Add("@UserInfoName", requestContainer.UserProfile.Name);
            parametersForProfile.Add("@UserInfoContactPref", string.Join(Constants.QuerySeparator, requestContainer.UserProfile.ContactPreference));
            parametersForProfile.Add("@UserInfoEmailAddress", requestContainer.UserProfile.EmailAddress);
            parametersForProfile.Add("@UserInfoAddress", new JavaScriptSerializer().Serialize(requestContainer.UserProfile.Address));
            parametersForProfile.Add("@IsAgent", requestContainer.UserProfile.IsAgent);
            parametersForProfile.Add("@IsManager", requestContainer.UserProfile.IsManager);
            parametersForProfile.Add("@LandingPage", requestContainer.UserProfile.LandingPage);
            parametersForProfile.Add("@Longitude", coordinates.Longitude);
            parametersForProfile.Add("@Latitude", coordinates.Latitude);
            parametersForProfile.Add("@AreaOfService", requestContainer.UserProfile.AreaOfService);
            parametersForProfile.Add("@AreaOfServiceTopLeftLat", null);
            parametersForProfile.Add("@AreaOfServiceTopLeftLng", null);
            parametersForProfile.Add("@AreaOfServiceBottomRightLat", null);
            parametersForProfile.Add("@AreaOfServiceBottomRightLng", null);
            parametersForProfile.Add("@Tags", null);
            parametersForProfile.Add("@userId", requestContainer.UserProfile.UserId);
            sqlProvider.ExecuteQuery(SqlQueries.UpdateUserProfile, parametersForProfile);

            returnContainer.IsAgent = requestContainer.UserProfile.IsAgent;

            returnContainer.Latitude = coordinates.Latitude;
            returnContainer.Longitude = coordinates.Longitude;

            returnContainer.ReturnCode = ReturnCodes.C101;

            return returnContainer;
        }
    }
}