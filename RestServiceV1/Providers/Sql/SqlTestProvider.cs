// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = SqlTestProvider.cs

namespace RestServiceV1.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Script.Serialization;
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
            else if (query == SqlQueries.GetUsersByIdsQuery(new List<string>(parameters.Where(x => x.Key.Contains("userId")).Select(x => x.Key).ToList<string>())))
            {
                return SqlTestProvider.GetUsersByIdsQuery(parameters.Where(x => x.Key.Contains("userId")).Select(x => x.Value.ToString()).ToList<string>());
            }
            else if (query == SqlQueries.GetUserCasesQuery)
            {
                return SqlTestProvider.GetUserCasesQuery();
            }
            else if (query == SqlQueries.GetUserCaseDetailsQuery)
            {
                return SqlTestProvider.GetUserCaseDetailsQuery();
            }
            else if (query == SqlQueries.GetAgentContextualInfoForUserCase)
            {
                return SqlTestProvider.GetUserCaseForAgentContext();
            }
            else if (query == SqlQueries.GetAgentsForUserCase)
            {
                return SqlTestProvider.GetAgentsForUserCase();
            }
            else if (query == SqlQueries.GetTagInfoForAddingNewTagToAgentQuery(new List<string>(parameters.Where(x => x.Key.Contains("tag")).Select(x => x.Key).ToList<string>())))
            {
                return SqlTestProvider.GetTagInfoForAddingNewTagToAgentQuery(parameters.Where(x => x.Key.Contains("tag")).Select(x => x.Value.ToString()).ToList<string>());
            }
            else if (query == SqlQueries.GetAgentCaseDetails)
            {
                return SqlTestProvider.GetAgentCaseDetails();
            }
            else if (query == SqlQueries.GetAgentCases)
            {
                return SqlTestProvider.GetAgentCases();
            }
            else if (query == SqlQueries.GetChatRoomDetails)
            {
                return SqlTestProvider.GetChatRoomDetails();
            }
            else if (query == SqlQueries.GetUserProfileQuery)
            {
                return SqlTestProvider.GetUserProfile();
            }
            else if (query == SqlQueries.GetTagsForAutoComplete)
            {
                return SqlTestProvider.GetTagsForAutoComplete();
            }
            else if (query == SqlQueries.GetAgentForAutoComplete)
            {
                return SqlTestProvider.GetAgentForAutoComplete();
            }
            else if (query == SqlQueries.GetUserRatingsFromContextualInfoQuery(true) || query == SqlQueries.GetUserRatingsFromContextualInfoQuery(false))
            {
                return SqlTestProvider.GetUserRatingsFromContextualInfoQuery();
            }

            return null;
        }

        private static DataSet GetUserRatingsFromContextualInfoQuery()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("Rating");
            table.Columns.Add("UserInfoTableRatingCount");
            table.Columns.Add("ContextualDetailsRatingCount");

            DataRow row1 = table.NewRow();
            row1["Rating"] = 3;
            row1["UserInfoTableRatingCount"] = 234;
            row1["ContextualDetailsRatingCount"] = 0;
            table.Rows.Add(row1);

            returnData.Tables.Add(table);
            return returnData;
        }

        private static DataSet GetAgentForAutoComplete()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("Name");
            table.Columns.Add("UserId");
            table.Columns.Add("PhoneNumber");
            table.Columns.Add("AgentRating");
            table.Columns.Add("AgentRatingCount");

            DataRow row1 = table.NewRow();
            row1["Name"] = "Jay Hastel";
            row1["UserId"] = Guid.NewGuid().ToString();
            row1["PhoneNumber"] = "+2134565739";
            row1["AgentRating"] = 2.3;
            row1["AgentRatingCount"] = 46;
            table.Rows.Add(row1);

            DataRow row2 = table.NewRow();
            row2["Name"] = "Polo Hasting";
            row2["UserId"] = Guid.NewGuid().ToString();
            row2["PhoneNumber"] = "+873263287";
            row2["AgentRating"] = 3.2;
            row2["AgentRatingCount"] = 576;
            table.Rows.Add(row2);

            DataRow row3 = table.NewRow();
            row3["Name"] = "Kavita Matlani";
            row3["UserId"] = Guid.NewGuid().ToString();
            row3["PhoneNumber"] = "+8973278656";
            row3["AgentRating"] = 4.3;
            row3["AgentRatingCount"] = 432;
            table.Rows.Add(row3);

            DataRow row4 = table.NewRow();
            row4["Name"] = "Bitty Jindal";
            row4["UserId"] = Guid.NewGuid().ToString();
            row4["PhoneNumber"] = "+876456";
            row4["AgentRating"] = 3.8;
            row4["AgentRatingCount"] = 312;
            table.Rows.Add(row4);

            DataRow row5 = table.NewRow();
            row5["Name"] = "Nima Jason";
            row5["UserId"] = Guid.NewGuid().ToString();
            row5["PhoneNumber"] = "+76764546579";
            row5["AgentRating"] = 2.7;
            row5["AgentRatingCount"] = 23;
            table.Rows.Add(row5);

            returnData.Tables.Add(table);
            return returnData;
        }

        private static DataSet GetTagsForAutoComplete()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("Tag");

            DataRow row = table.NewRow();
            row["Tag"] = "Test1";
            table.Rows.Add(row);

            DataRow row2 = table.NewRow();
            row2["Tag"] = "Test2";
            table.Rows.Add(row2);

            DataRow row3 = table.NewRow();
            row3["Tag"] = "Test3";
            table.Rows.Add(row3);

            DataRow row4 = table.NewRow();
            row4["Tag"] = "Test11111111111111111111111111111";
            table.Rows.Add(row4);

            DataRow row5 = table.NewRow();
            row5["Tag"] = "Test23";
            table.Rows.Add(row5);

            returnData.Tables.Add(table);
            return returnData;
        }

        private static DataSet GetUserProfile()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("Name");
            table.Columns.Add("PhoneNumber");
            table.Columns.Add("IsVerified");
            table.Columns.Add("ContactPref");
            table.Columns.Add("EmailAddress");
            table.Columns.Add("Address");
            table.Columns.Add("IsAgent");
            table.Columns.Add("IsManager");
            table.Columns.Add("LandingPage");
            table.Columns.Add("PushNotificationsUri");
            table.Columns.Add("AgentRating");
            table.Columns.Add("AgentRatingCount");
            table.Columns.Add("UserRating");
            table.Columns.Add("UserRatingCount");
            table.Columns.Add("Tags");
            table.Columns.Add("AreaofService");
            table.Columns.Add("FavoriteAgents");

            DataRow row1 = table.NewRow();
            row1["Name"] = "Rittu Jain";
            row1["PhoneNumber"] = "+919867856543";
            row1["IsVerified"] = true;
            row1["ContactPref"] = "Chat" + Constants.QuerySeparator + "Email"; ;
            row1["EmailAddress"] = "Rittu@Jain.com";
            AddressContainer addressContainer = new AddressContainer();
            addressContainer.AddressLine1 = "1000 Having St";
            addressContainer.City = "Hasting";
            addressContainer.PostalCode = "40001";
            addressContainer.Country = "USA";
            row1["Address"] = new JavaScriptSerializer().Serialize(addressContainer);
            row1["IsAgent"] = true;
            row1["IsManager"] = true;
            row1["LandingPage"] = "Agent";
            row1["PushNotificationsUri"] = "Junk";
            row1["AgentRating"] = 4.5;
            row1["AgentRatingCount"] = 56;
            row1["UserRating"] = 4.5;
            row1["UserRatingCount"] = 56;
            row1["Tags"] = "PartyPlaning|$|CabService|$|Balloons";
            row1["AreaOfService"] = 20.0;
            row1["FavoriteAgents"] = null;
            table.Rows.Add(row1);

            returnData.Tables.Add(table);
            return returnData;
        }

        private static DataSet GetChatRoomDetails()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("CaseId");
            table.Columns.Add("ChatId");
            table.Columns.Add("ParticipantsUsers");
            table.Columns.Add("ParticipantsAgents");

            DataRow row1 = table.NewRow();
            row1["CaseId"] = Guid.NewGuid().ToString();
            row1["ChatId"] = Guid.NewGuid().ToString();
            row1["ParticipantsUsers"] = "User";
            row1["ParticipantsAgents"] = "Agents";
            table.Rows.Add(row1);

            returnData.Tables.Add(table);
            return returnData;
        }

        private static DataSet GetAgentCases()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("CaseId");
            table.Columns.Add("Title");
            table.Columns.Add("NewMessage");
            table.Columns.Add("IsEnterpriseTag");
            table.Columns.Add("AssignedAgentId");
            table.Columns.Add("AssignedAgentName");
            table.Columns.Add("UserName");
            table.Columns.Add("DateTimeUpdated");

            DataRow row1 = table.NewRow();
            row1["CaseId"] = Guid.NewGuid().ToString();
            row1["Title"] = "Get me flowers";
            row1["NewMessage"] = true;
            row1["IsEnterpriseTag"] = true;
            row1["AssignedAgentId"] = Guid.NewGuid().ToString();
            row1["AssignedAgentName"] = "Iyer Thanupatil";
            row1["UserName"] = "Borat Sigh";
            row1["DateTimeUpdated"] = DateTimeOffset.Now;
            table.Rows.Add(row1);

            DataRow row2 = table.NewRow();
            row2["CaseId"] = Guid.NewGuid().ToString();
            row2["Title"] = "Plan a party";
            row2["NewMessage"] = true;
            row1["IsEnterpriseTag"] = false;
            row2["AssignedAgentId"] = string.Empty;
            row2["AssignedAgentName"] = string.Empty;
            row1["UserName"] = "Ravi Gita Sigh";
            row2["DateTimeUpdated"] = DateTimeOffset.Now.AddDays(-1);
            table.Rows.Add(row2);

            DataRow row3 = table.NewRow();
            row3["CaseId"] = Guid.NewGuid().ToString();
            row3["Title"] = "Help with my math HW";
            row3["NewMessage"] = false;
            row1["IsEnterpriseTag"] = true;
            row3["AssignedAgentId"] = Guid.NewGuid().ToString();
            row3["AssignedAgentName"] = "Karpi Manjunath";
            row1["UserName"] = "Sita Panchantagali";
            row3["DateTimeUpdated"] = DateTimeOffset.Now;
            table.Rows.Add(row3);

            returnData.Tables.Add(table);
            return returnData;
        }

        private static DataSet GetAgentCaseDetails()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("CaseId");
            table.Columns.Add("Title");
            table.Columns.Add("RequestDetails");
            table.Columns.Add("Budget");
            table.Columns.Add("ContactPref");
            table.Columns.Add("ContextId");
            table.Columns.Add("UserId");
            table.Columns.Add("AgentId");
            table.Columns.Add("AgentNotes");
            table.Columns.Add("Quote");
            table.Columns.Add("Timeline");
            table.Columns.Add("PaymentStatus");

            DataRow row1 = table.NewRow();
            row1["CaseId"] = Guid.NewGuid().ToString();
            row1["Title"] = "I want to get flowers delivered";
            row1["RequestDetails"] = "Please could you deliver flowers to my friend. It is his birthday.";
            row1["Budget"] = 400;
            row1["ContactPref"] = "Chat" + Constants.QuerySeparator + "Email";
            row1["ContextId"] = Guid.NewGuid().ToString();
            row1["UserId"] = Guid.NewGuid().ToString();
            row1["AgentId"] = Guid.NewGuid().ToString();
            row1["AgentNotes"] = "This customer is awesome";
            row1["Quote"] = "200";
            row1["Timeline"] = "2 hours";
            row1["PaymentStatus"] = "Not paid";
            table.Rows.Add(row1);

            returnData.Tables.Add(table);
            return returnData;
        }

        private static DataSet GetTagInfoForAddingNewTagToAgentQuery(List<string> tags)
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("Tag");
            table.Columns.Add("IsEnterpriseTag");
            table.Columns.Add("DateTimeTagCode");
            table.Columns.Add("Code");
            table.Columns.Add("AgentIdGroup1");

            if (tags.Count == 1)
            {
                DataRow row1 = table.NewRow();
                row1["Tag"] = tags[0];
                row1["IsEnterpriseTag"] = true;
                row1["DateTimeTagCode"] = DateTimeOffset.UtcNow.AddMinutes(5);
                row1["Code"] = 1234;
                row1["AgentIdGroup1"] = "Test";
                table.Rows.Add(row1);
            }

            returnData.Tables.Add(table);
            return returnData;
        }

        private static DataSet GetAgentsForUserCase()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("AgentId");
            table.Columns.Add("Name");
            table.Columns.Add("AgentRating");
            table.Columns.Add("AgentRatingCount");

            DataRow row1 = table.NewRow();
            row1["AgentId"] = Guid.NewGuid().ToString();
            row1["Name"] = "Raj Jackmar";
            row1["AgentRating"] = 4.5;
            row1["AgentRatingCount"] = 273;
            table.Rows.Add(row1);

            DataRow row2 = table.NewRow();
            row2["AgentId"] = Guid.NewGuid().ToString();
            row2["Name"] = "Peter Thum";
            row2["AgentRating"] = 3.1;
            row2["AgentRatingCount"] = 326;
            table.Rows.Add(row2);

            DataRow row3 = table.NewRow();
            row3["AgentId"] = Guid.NewGuid().ToString();
            row3["Name"] = "Sita Gills";
            row3["AgentRating"] = 4.8;
            row3["AgentRatingCount"] = 65;
            table.Rows.Add(row3);

            returnData.Tables.Add(table);
            return returnData;
        }

        private static DataSet GetUserCaseForAgentContext()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("ContextId");
            table.Columns.Add("UserId");
            table.Columns.Add("AgentId");
            table.Columns.Add("AgentName");
            table.Columns.Add("UserNotes");
            table.Columns.Add("Quote");
            table.Columns.Add("Timeline");
            table.Columns.Add("PaymentStatus");

            DataRow row1 = table.NewRow();
            row1["ContextId"] = Guid.NewGuid().ToString();
            row1["UserId"] = Guid.NewGuid().ToString();
            row1["AgentId"] = Guid.NewGuid().ToString();
            row1["AgentName"] = "Tempar Chandani";
            row1["UserNotes"] = "This agent is awesome";
            row1["Quote"] = 200;
            row1["Timeline"] = "2 hours";
            row1["PaymentStatus"] = "Not paid";
            table.Rows.Add(row1);

            returnData.Tables.Add(table);
            return returnData;
        }

        private static DataSet GetUserCaseDetailsQuery()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("CaseId");
            table.Columns.Add("Title");
            table.Columns.Add("RequestDetails");
            table.Columns.Add("Budget");
            table.Columns.Add("AssignedAgentId");

            DataRow row1 = table.NewRow();
            row1["CaseId"] = Guid.NewGuid().ToString();
            row1["Title"] = "Get me some chocolate to eat";
            row1["RequestDetails"] = "I would like to eat some cake from this bakery down at patia lane. Can you come deliver it to me?";
            row1["Budget"] = 450;
            row1["AssignedAgentId"] = Guid.NewGuid().ToString();
            table.Rows.Add(row1);

            returnData.Tables.Add(table);
            return returnData;
        }

        private static DataSet GetUserCasesQuery()
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("CaseId");
            table.Columns.Add("Title");
            table.Columns.Add("NewMessage");
            table.Columns.Add("AssignedAgentId");
            table.Columns.Add("AssignedAgentName");
            table.Columns.Add("DateTimeUpdated");

            DataRow row1 = table.NewRow();
            row1["CaseId"] = Guid.NewGuid().ToString();
            row1["Title"] = "Get me flowers";
            row1["NewMessage"] = true;
            row1["AssignedAgentId"] = Guid.NewGuid().ToString();
            row1["AssignedAgentName"] = "Iyer Thanupatil";
            row1["DateTimeUpdated"] = DateTimeOffset.Now;
            table.Rows.Add(row1);

            DataRow row2 = table.NewRow();
            row2["CaseId"] = Guid.NewGuid().ToString();
            row2["Title"] = "Plan a party";
            row2["NewMessage"] = true;
            row2["AssignedAgentId"] = string.Empty;
            row2["AssignedAgentName"] = string.Empty;
            row2["DateTimeUpdated"] = DateTimeOffset.Now.AddDays(-1);
            table.Rows.Add(row2);

            DataRow row3 = table.NewRow();
            row3["CaseId"] = Guid.NewGuid().ToString();
            row3["Title"] = "Help with my math HW";
            row3["NewMessage"] = false;
            row3["AssignedAgentId"] = Guid.NewGuid().ToString();
            row3["AssignedAgentName"] = "Karpi Manjunath";
            row3["DateTimeUpdated"] = DateTimeOffset.Now;
            table.Rows.Add(row3);

            returnData.Tables.Add(table);
            return returnData;
        }

        /// <summary>
        /// Gets the agents by ids query.
        /// </summary>
        /// <returns></returns>
        private static DataSet GetUsersByIdsQuery(List<string> userIds)
        {
            DataSet returnData = new DataSet();
            DataTable table = new DataTable("InfoTable");
            table.Columns.Add("UserId");
            table.Columns.Add("Name");
            table.Columns.Add("AgentRating");
            table.Columns.Add("AgentRatingCount");
            table.Columns.Add("Tags");
            table.Columns.Add("FavoriteAgents");
            table.Columns.Add("PushNotificationsUri");

            DataRow row1 = table.NewRow();
            row1["UserId"] = userIds[0];
            row1["Name"] = "Raj Jackmar";
            row1["AgentRating"] = 4.5;
            row1["AgentRatingCount"] = 273;
            row1["AreaOfService"] = 20;
            row1["Tags"] = "PartyPlaning|$|CabService|$|Balloons";
            row1["FavoriteAgents"] = Guid.NewGuid().ToString() + "|$|" + Guid.NewGuid().ToString();
            row1["PushNotificationsUri"] = "Teststring";
            table.Rows.Add(row1);

            DataRow row2 = table.NewRow();
            row2["UserId"] = userIds[1];
            row2["Name"] = "Peter Thum";
            row2["AgentRating"] = 3.1;
            row2["AgentRatingCount"] = 326;
            row2["AreaOfService"] = 25;
            row2["Tags"] = "DJ|$|Music";
            row2["FavoriteAgents"] = Guid.NewGuid().ToString();
            row1["PushNotificationsUri"] = "Teststring";
            table.Rows.Add(row2);

            if (userIds.Count > 2)
            {

                DataRow row3 = table.NewRow();
                row3["UserId"] = Guid.NewGuid().ToString();
                row3["Name"] = "Sita Gills";
                row3["AgentRating"] = 4.8;
                row3["AgentRatingCount"] = 65;
                row3["AreaOfService"] = 5;
                row3["Tags"] = "Flowers";
                row3["FavoriteAgents"] = string.Empty;
            row1["PushNotificationsUri"] = "Teststring";
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
            table.Columns.Add("AgentRating");

            // Exactly one day
            DataRow row1 = table.NewRow();
            row1["UserId"] = "97f20b24-0cd1-4c7b-8d70-563fa0d98167";
            table.Rows.Add(row1);

            returnData.Tables.Add(table);
            return returnData;
        }
    }
}