// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = SqlTestProvider.cs

namespace RestServiceV1.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Test provider for the ISqlProvider interface
    /// </summary>
    public class SqlTestProvider : ISqlProvider
    {
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// DataSet of the query
        /// </returns>
        DataSet ISqlProvider.ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            if (query == SqlQueries.CheckIfPhoneNumberRegisteredQuery)
            {
                return SqlTestProvider.CheckIfPhoneNumberRegisteredQuery();
            }
            else if (query == SqlQueries.RetrieveDeviceVerificationCode)
            {
                return SqlTestProvider.RetrieveDeviceVerificationCode();
            }
            else if (query == SqlQueries.GetAgentsForTagQuery(new List<string>(parameters.Where(x => x.Key.Contains("tag")).Select(x => x.Key).ToList<string>())))
            {
                return SqlTestProvider.GetAgentsForTag();
            }
            else if (query == SqlQueries.GetTagKeywordMap)
            {
                return SqlTestProvider.GetTagKeywordMap();
            }
            else if (query == SqlQueries.GetAgentsByIdsQuery(new List<string>(parameters.Where(x => x.Key.Contains("userId")).Select(x => x.Key).ToList<string>())))
            {
                return SqlTestProvider.GetAgentsByIdsQuery(parameters.Where(x => x.Key.Contains("userId")).Select(x => x.Value.ToString()).ToList<string>());
            }

            return null;
        }

        /// <summary>
        /// Gets the agents by ids query.
        /// </summary>
        /// <returns></returns>
        private static DataSet GetAgentsByIdsQuery(List<string> userIds)
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("UserId");
            table.Columns.Add("Name");
            table.Columns.Add("Rating");
            table.Columns.Add("NumberOfRatings");
            table.Columns.Add("AreaOfService");
            table.Columns.Add("Tags");
            table.Columns.Add("FavoriteAgents");

            DataRow row1 = table.NewRow();
            row1["UserId"] = userIds[0];
            row1["Name"] = "Raj Jackmar";
            row1["Rating"] = 4.5;
            row1["NumberOfRatings"] = 273;
            row1["AreaOfService"] = "Mumbai";
            row1["Tags"] = "PartyPlaning|$|CabService|$|Balloons";
            row1["FavoriteAgents"] = Guid.NewGuid().ToString() + "|$|" + Guid.NewGuid().ToString();
            table.Rows.Add(row1);

            DataRow row2 = table.NewRow();
            row2["UserId"] = userIds[1];
            row2["Name"] = "Peter Thum";
            row2["Rating"] = 3.1;
            row2["NumberOfRatings"] = 326;
            row2["AreaOfService"] = "Delhi";
            row2["Tags"] = "DJ|$|Music";
            row2["FavoriteAgents"] = Guid.NewGuid().ToString();
            table.Rows.Add(row2);

            if (userIds.Count > 2)
            {

                DataRow row3 = table.NewRow();
                row3["UserId"] = Guid.NewGuid().ToString();
                row3["Name"] = "Sita Gills";
                row3["Rating"] = 4.8;
                row3["NumberOfRatings"] = 65;
                row3["AreaOfService"] = "South Mumbai";
                row3["Tags"] = "Flowers";
                row3["FavoriteAgents"] = string.Empty;
                table.Rows.Add(row3);
            }

            returnData.Tables.Add(table);
            return returnData;
        }

        /// <summary>
        /// Gets the tag keyword map.
        /// </summary>
        /// <returns></returns>
        private static DataSet GetTagKeywordMap()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("Tag");
            table.Columns.Add("Keyword");

            DataRow row1 = table.NewRow();
            row1["Tag"] = "DJ";
            row1["Keyword"] = "party|$|rock|$|music";
            table.Rows.Add(row1);

            DataRow row2 = table.NewRow();
            row2["Tag"] = "Florists";
            row2["Keyword"] = "flowers|$|delivery|$|anniversary";
            table.Rows.Add(row2);

            returnData.Tables.Add(table);
            return returnData;
        }

        /// <summary>
        /// Gets the agents for tag.
        /// </summary>
        /// <returns></returns>
        private static DataSet GetAgentsForTag()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("AgentIdGroup1");
            table.Columns.Add("AgentIdGroup2");

            DataRow row1 = table.NewRow();
            row1["AgentIdGroup1"] = "be3136e5-556b-4da5-977f-bb192f7829bf|$|8e68681e-9649-4cbe-b249-0bf51b2e5766|$|12f2c6df-f778-4913-aa9e-28e4899ce050";
            row1["AgentIdGroup2"] = string.Empty;
            table.Rows.Add(row1);

            DataRow row2 = table.NewRow();
            row2["AgentIdGroup1"] = "60dcfa50-9ad7-42c3-80b2-b3c03504aaf1|$|4edf5fed-b37e-4a75-948a-1e2b5a25b6ff";
            row2["AgentIdGroup2"] = "bf1fdeb5-1328-4e8a-a809-d2f017e2730e";
            table.Rows.Add(row2);

            returnData.Tables.Add(table);
            return returnData;
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
            table.Columns.Add("TimeStamp");

            // Exactly one day
            DataRow row1 = table.NewRow();
            row1["VerificationCode"] = "1234";
            row1["TimeStamp"] = DateTime.Now.AddMinutes(5).ToString();
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