// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetChatRoomDetailsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using DataContracts;
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Get chat room details command
    /// </summary>
    public class GetChatRoomDetailsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetChatRoomDetailsRequestContainer requestContainer = context.InParam as GetChatRoomDetailsRequestContainer;
            GetChatRoomDetailsReturnContainer returnContainer = new GetChatRoomDetailsReturnContainer();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@caseId", requestContainer.CaseId);

            DataSet results = sqlProvider.ExecuteQuery(SqlQueries.GetChatRoomDetails, parameters);

            if (results.Tables.Count < 1)
            {
                throw new ApplicationException("Query error");
            }

            if (results.Tables[0].Rows.Count == 0)
            {
                Dictionary<string, object> insertParameters = new Dictionary<string, object>();
                insertParameters.Add("@dateTimeCreated", DateTimeOffset.UtcNow.ToString());
                insertParameters.Add("@dateTimeUpdated", DateTimeOffset.UtcNow.ToString());
                insertParameters.Add("@chatId", Guid.NewGuid().ToString());
                insertParameters.Add("@caseId", requestContainer.CaseId);
                insertParameters.Add("@agents", requestContainer.AgentId);
                insertParameters.Add("@users", requestContainer.UserId);
                insertParameters.Add("@deleted", false);

                sqlProvider.ExecuteQuery(SqlQueries.InsertChatRoomDetails, insertParameters);

                results = sqlProvider.ExecuteQuery(SqlQueries.GetChatRoomDetails, parameters);
                if (results.Tables.Count < 1 && results.Tables[0].Rows.Count != 1)
                {
                    throw new ApplicationException("Query error");
                }
            }

            DataRow row = results.Tables[0].Rows[0];
            returnContainer.CaseId = row["CaseId"].ToString();
            returnContainer.ChatId = row["ChatId"].ToString();
            returnContainer.ParticipantsInfo = new List<MyKeyValuePair<string, string>>();

            string customerId = row["ParticipantsUsers"].ToString();

            parameters = new Dictionary<string, object>();
            List<string> participants = row["ParticipantsAgents"].ToString().Split(new string[] { Constants.QuerySeparator }, StringSplitOptions.RemoveEmptyEntries).ToList();
            participants.Add(customerId);
            for (int i = 0; i < participants.Count; i++)
            {
                parameters.Add("@userId" + i, participants[i]);
            }

            DataSet agentInfoResult = sqlProvider.ExecuteQuery(SqlQueries.GetUsersByIdsQuery(participants.ToList()), parameters);
            if (agentInfoResult.Tables.Count < 1)
            {
                throw new ApplicationException("Query error");
            }

            returnContainer.ParticipantsInfo = new List<MyKeyValuePair<string, string>>();
            returnContainer.UserIdNamePairs = new List<MyKeyValuePair<string, string>>();
            foreach (DataRow dataRow in agentInfoResult.Tables[0].Rows)
            {
                string userId = dataRow["UserId"].ToString();
                returnContainer.ParticipantsInfo.Add(new MyKeyValuePair<string, string>(userId, dataRow["PushNotificationsUri"].ToString()));
                returnContainer.UserIdNamePairs.Add(new MyKeyValuePair<string, string>(userId, dataRow["Name"].ToString()));
            }

            if (customerId != requestContainer.UserId)
            {
                returnContainer.UserType = 1;
            }

            // Todo: First name
            returnContainer.ChatRoomTitle = string.Join(", ", returnContainer.UserIdNamePairs.Select(x => x.Second));
            
            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}