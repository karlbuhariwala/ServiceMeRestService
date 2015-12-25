// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetUserTagsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using DataContracts;
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Get user tags command
    /// </summary>
    public class GetUserTagsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Base return container</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetUserTagsRequestContainer requestContainer = context.InParam as GetUserTagsRequestContainer;
            GetUserTagsReturnContainer returnContainer = new GetUserTagsReturnContainer();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@userId", requestContainer.UserId }, { "@deleted", false } };
            DataSet returnedData = sqlProvider.ExecuteQuery(SqlQueries.GetUserProfileQuery, parameters);
            if (returnedData.Tables.Count > 0 && returnedData.Tables[0].Rows.Count == 1)
            {
                DataRow row = returnedData.Tables[0].Rows[0];
                returnContainer.Tags = row["Tags"].ToString().Split(new string[] { Constants.QuerySeparator }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                double tempDouble;
                double.TryParse(row["AreaOfService"].ToString(), out tempDouble);
                returnContainer.AreaOfService = tempDouble;
                returnContainer.ReturnCode = ReturnCodes.C101;
            }
            else
            {
                // User does not exist
                returnContainer.ReturnCode = ReturnCodes.C001;
            }

            return returnContainer;
        }
    }
}