// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = CreateNewUserCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using RestServiceV1.Providers;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    /// <summary>
    /// CreateNewUserCommand class
    /// </summary>
    public class CreateNewUserCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            CreateNewUserRequestContainer requestContainer = context.InParam as CreateNewUserRequestContainer;
            CreateNewUserReturnContainer returnContainer = new CreateNewUserReturnContainer();

            StringBuilder sb = new StringBuilder();
            sb.Append("+");
            for (int i = 0; i < requestContainer.PhoneNumber.Length; i++)
            {
                int temp;
                if (int.TryParse(requestContainer.PhoneNumber[i].ToString(), out temp))
                {
                    sb.Append(temp);
                }
            }

            string phoneNumber = sb.ToString();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            DataSet user = sqlProvider.ExecuteQuery(SqlQueries.CheckIfPhoneNumberRegisteredQuery, new Dictionary<string, object>() { { "@phoneNumber", phoneNumber } });
            bool exists = false;
            string userId = string.Empty;
            if (user.Tables[0].Rows.Count == 1)
            {
                userId = user.Tables[0].Rows[0]["UserId"].ToString();
                exists = true;
            }

            if (requestContainer.DeviceType == DeviceType.Phone.ToString())
            {
                if (exists)
                {
                    returnContainer.UserId = userId;

                    // User does exist and verification text has been sent to the phone.
                    returnContainer.ReturnCode = ReturnCodes.C102;
                }
                else
                {
                    returnContainer.UserId = Guid.NewGuid().ToString();
                    UserProfile userProfile = new UserProfile();
                    userProfile.UserId = returnContainer.UserId;
                    userProfile.PhoneNumber = requestContainer.PhoneNumber;

                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@userId", returnContainer.UserId);
                    parameters.Add("@phoneNumber", phoneNumber);
                    parameters.Add("@isVerified", 0);
                    parameters.Add("@isAgent", 0);
                    parameters.Add("@isManager", 0);
                    parameters.Add("@deleted", 0);
                    parameters.Add("@dateTimeCreated", DateTimeOffset.UtcNow);
                    parameters.Add("@dateTimeUpdated", DateTimeOffset.UtcNow);

                    sqlProvider.ExecuteQuery(SqlQueries.CreateNewProfileQuery, parameters);
                    returnContainer.ReturnCode = ReturnCodes.C101;
                }

                // Todo: Verification text module needs to be called.

                Dictionary<string, object> parameters1 = new Dictionary<string, object>();
                parameters1.Add("@userId", returnContainer.UserId);
                parameters1.Add("@VerificationCode", 1234);
                parameters1.Add("@TimeStamp", DateTimeOffset.UtcNow);
                parameters1.Add("@Deleted", 0);
                sqlProvider.ExecuteQuery(SqlQueries.InsertDeviceVerificationCode, parameters1);
            }
            else if (requestContainer.DeviceType == DeviceType.Computer.ToString())
            {
                if (exists)
                {
                    returnContainer.UserId = userId;

                    // User does exist and push notification sent to phone with verification code
                    returnContainer.ReturnCode = ReturnCodes.C104;

                    // Todo: Verification text module needs to be called.

                    Dictionary<string, object> parameters1 = new Dictionary<string, object>();
                    parameters1.Add("@userId", returnContainer.UserId);
                    parameters1.Add("@VerificationCode", 1234);
                    parameters1.Add("@TimeStamp", DateTimeOffset.UtcNow);
                    parameters1.Add("@Deleted", 0);
                    sqlProvider.ExecuteQuery(SqlQueries.InsertDeviceVerificationCode, parameters1);
                }
                else
                {
                    // User does not exist and needs to create user on a phone.
                    returnContainer.ReturnCode = ReturnCodes.C103;
                }
            }
            else
            {
                // Todo: Log and exception
            }

            return returnContainer;
        }
    }
}