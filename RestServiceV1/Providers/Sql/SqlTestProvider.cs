// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = SqlTestProvider.cs

namespace RestServiceV1.Providers
{
    using System;
    using System.Data;

    /// <summary>
    /// Test provider for the ISqlProvider interface
    /// </summary>
    public class SqlTestProvider : ISqlProvider
    {
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// DataSet of the query
        /// </returns>
        DataSet ISqlProvider.ExecuteQuery(string query)
        {
            if (query == SqlQueries.CheckIfPhoneNumberRegisteredQuery)
            {
                return SqlTestProvider.CheckIfPhoneNumberRegisteredQuery();
            }
            else if (query == SqlQueries.RetrieveDeviceVerificationCode)
            {
                return SqlTestProvider.RetrieveDeviceVerificationCode();
            }

            return null;
        }

        /// <summary>
        /// Retrieves the device verification code.
        /// </summary>
        /// <returns></returns>
        private static DataSet RetrieveDeviceVerificationCode()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("VerificationCode");
            table.Columns.Add("ExpiryTime");

            // Exactly one day
            DataRow row1 = table.NewRow();
            row1["VerificationCode"] = "1234";
            row1["ExpiryTime"] = DateTime.Now.AddMinutes(5).ToString();
            table.Rows.Add(row1);

            returnData.Tables.Add(table);
            return returnData;
        }

        /// <summary>
        /// Checks if phone number registered query.
        /// </summary>
        /// <returns></returns>
        private static DataSet CheckIfPhoneNumberRegisteredQuery()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("UserId");
            table.Columns.Add("PhoneNumber");
            table.Columns.Add("Name");
            table.Columns.Add("IsVerified");
            table.Columns.Add("ContactPreference");
            table.Columns.Add("Address");
            table.Columns.Add("PaymentDetails");
            table.Columns.Add("IsAgent");
            table.Columns.Add("IsManager");
            table.Columns.Add("LandingPage");
            table.Columns.Add("PushNotificationUri");
            table.Columns.Add("Rating");

            // Exactly one day
            DataRow row1 = table.NewRow();
            row1["UserId"] = "97f20b24-0cd1-4c7b-8d70-563fa0d98167";
            table.Rows.Add(row1);

            returnData.Tables.Add(table);
            return returnData;
        }
    }
}