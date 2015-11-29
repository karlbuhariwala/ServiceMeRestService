// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetTagsForAutoCompleteCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using Providers;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Command to get the tags for autocomplete
    /// </summary>
    public class GetTagsForAutoCompleteCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetTagsForAutoCompleteRequestContainer requestContainer = context.InParam as GetTagsForAutoCompleteRequestContainer;
            GetTagsForAutoCompleteReturnContainer returnContainer = new GetTagsForAutoCompleteReturnContainer();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@deleted", false } };
            parameters.Add("@tag", string.Format("%{0}%", requestContainer.Text));

            DataSet result = sqlProvider.ExecuteQuery(SqlQueries.GetTagsForAutoComplete, parameters);

            returnContainer.SuggestedTags = new List<string>();
            if (result.Tables.Count > 0)
            {
                foreach (DataRow row in result.Tables[0].Rows)
                {
                    returnContainer.SuggestedTags.Add(row["Tag"].ToString());
                }
            }

            returnContainer.ReturnCode = ReturnCodes.C101;

            return returnContainer;
        }
    }
}