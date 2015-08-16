// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = CreateNewUserCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using RestServiceV1.Providers;
    using System;
    using System.Data;

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

            // Todo: Optimize only getting user as per query
            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>();
            DataSet user = sqlProvider.ExecuteQuery(SqlQueries.CheckIfPhoneNumberRegisteredQuery);
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

                    sqlProvider.ExecuteQuery(SqlQueries.CreateNewProfileQuery);
                    returnContainer.ReturnCode = ReturnCodes.C101;
                }

                // Todo: Verification text module needs to be called.
                DeviceValidationContainer deviceValidationContainer = new DeviceValidationContainer() { DeviceType = "Phone", UserId = returnContainer.UserId, ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(5) };
                deviceValidationContainer.VerificationCode = 1234;

                sqlProvider.ExecuteQuery(SqlQueries.InsertDeviceVerificationCode);
            }
            else if (requestContainer.DeviceType == DeviceType.Computer.ToString())
            {
                if (exists)
                {
                    returnContainer.UserId = userId;

                    // User does exist and push notification sent to phone with verification code
                    returnContainer.ReturnCode = ReturnCodes.C104;
                    // Todo: Send notification with verification code to phone
                    DeviceValidationContainer deviceValidationContainer = new DeviceValidationContainer() { DeviceType = "Computer", UserId = returnContainer.UserId, ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(5) };
                    deviceValidationContainer.VerificationCode = 1234;

                    sqlProvider.ExecuteQuery(SqlQueries.InsertDeviceVerificationCode);
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