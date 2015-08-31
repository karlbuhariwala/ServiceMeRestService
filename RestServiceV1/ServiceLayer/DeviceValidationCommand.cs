// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = DeviceValidationCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using RestServiceV1.Providers;
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Command to do the device validation
    /// </summary>
    public class DeviceValidationCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            DeviceValidationRequestContainer requestContainer = context.InParam as DeviceValidationRequestContainer;
            DeviceValidationReturnContainer returnContainer = new DeviceValidationReturnContainer();

            DateTimeOffset timestamp = DateTimeOffset.UtcNow;

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@userId", requestContainer.UserId }, { "@deleted", false } };
            DataSet returnedData = sqlProvider.ExecuteQuery(SqlQueries.RetrieveDeviceVerificationCode, parameters);
            if (returnedData.Tables[0].Rows.Count == 1)
            {
                DeviceValidationContainer deviceValidationContainer = new DeviceValidationContainer();
                deviceValidationContainer.VerificationCode = int.Parse(returnedData.Tables[0].Rows[0]["VerificationCode"].ToString());
                deviceValidationContainer.ExpiryTime = DateTime.Parse(returnedData.Tables[0].Rows[0]["TimeStamp"].ToString()).AddMinutes(5);

                bool verified = (deviceValidationContainer.VerificationCode == requestContainer.ValidationCode &&
                                 deviceValidationContainer.ExpiryTime > timestamp);
                if (verified)
                {
                    // Verified and valid
                    returnContainer.ReturnCode = ReturnCodes.C101;
                    sqlProvider.ExecuteQuery(SqlQueries.DeleteVerificationEntry, parameters);
                }
                else
                {
                    if (deviceValidationContainer.ExpiryTime < timestamp)
                    {
                        // User found and code has expired. Needs to close app and start again.
                        returnContainer.ReturnCode = ReturnCodes.C103;
                        sqlProvider.ExecuteQuery(SqlQueries.DeleteVerificationEntry, parameters);
                    }
                    else
                    {
                        // UserFound but not valid code
                        returnContainer.ReturnCode = ReturnCodes.C102;
                    }
                }
            }
            else
            {
                // No user entry found. Need to restart App.
                returnContainer.ReturnCode = ReturnCodes.C001;
            }

            return returnContainer;
        }
    }
}