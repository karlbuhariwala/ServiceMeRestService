// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = SaveNewCaseCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using Providers;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    /// <summary>
    /// Command to save a new case from the user
    /// </summary>
    public class SaveNewCaseCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            SaveNewCaseRequestContainer requestContainer = context.InParam as SaveNewCaseRequestContainer;
            SaveNewCaseReturnContainer returnContainer = new SaveNewCaseReturnContainer();

            Guid caseId = Guid.NewGuid();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@caseId", caseId);
            parameters.Add("@userId", requestContainer.CaseInfo.UserId);
            parameters.Add("@userName", requestContainer.CaseInfo.UserName);
            parameters.Add("@title", requestContainer.CaseInfo.Title);
            parameters.Add("@contactPref", string.Join(Constants.QuerySeparator, requestContainer.CaseInfo.ContactPreference));
            parameters.Add("@tags", string.Join(Constants.QuerySeparator, requestContainer.CaseInfo.Tags.Distinct()));
            parameters.Add("@requestDetails", requestContainer.CaseInfo.RequestDetails);
            parameters.Add("@budget", requestContainer.CaseInfo.Budget);
            parameters.Add("@address", requestContainer.CaseInfo.UserAddress);
            parameters.Add("@anotherAddress", requestContainer.CaseInfo.AnotherAddress);
            // Todo: Update after tags table is created
            parameters.Add("@isEnterpriseTag", false);
            parameters.Add("@deleted", false);
            parameters.Add("@dateTimeCreated", DateTimeOffset.UtcNow);
            parameters.Add("@dateTimeUpdated", DateTimeOffset.UtcNow);
            sqlProvider.ExecuteQuery(SqlQueries.CreateNewCase, parameters);

            // Todo: Make concurrent
            foreach (var agentId in requestContainer.AgentIds)
            {
                parameters = new Dictionary<string, object>();
                parameters.Add("@caseId", caseId);
                parameters.Add("@agentId", agentId);
                parameters.Add("@blocked", false);
                parameters.Add("@deleted", false);
                parameters.Add("@dateTimeCreated", DateTimeOffset.UtcNow);
                parameters.Add("@dateTimeUpdated", DateTimeOffset.UtcNow);
                sqlProvider.ExecuteQuery(SqlQueries.AddToAgentCaseMap, parameters);
            }

            foreach (var tag in requestContainer.CaseInfo.Tags)
            {
                parameters = new Dictionary<string, object>();
                parameters.Add("@caseId", caseId);
                parameters.Add("@tag", tag);
                parameters.Add("@closed", false);
                parameters.Add("@deleted", false);
                parameters.Add("@dateTimeCreated", DateTimeOffset.UtcNow);
                parameters.Add("@dateTimeUpdated", DateTimeOffset.UtcNow);
                sqlProvider.ExecuteQuery(SqlQueries.AddToTagCaseMap, parameters);
            }

            // Add to user prefered requests

            returnContainer.ReturnCode = ReturnCodes.C101;

            return returnContainer;
        }
    }
}