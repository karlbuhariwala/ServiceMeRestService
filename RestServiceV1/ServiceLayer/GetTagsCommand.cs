// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetTagsCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using RestServiceV1.Providers;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Get Tags Command
    /// </summary>
    public class GetTagsCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetTagsRequestContainer requestContainer = context.InParam as GetTagsRequestContainer;
            GetTagsReturnContainer returnContainer = new GetTagsReturnContainer();

            INlpProvider nlpProvider = (INlpProvider)ProviderFactory.Instance.CreateProvider<INlpProvider>(null);
            Dictionary<string, IEnumerable<string>> keywordsCollection = (Dictionary<string, IEnumerable<string>>)nlpProvider.GetRelevantTerms(requestContainer.CaseDetails.RequestDetails);
            List<string> keywords = new List<string>();
            foreach (var keywordCollection in keywordsCollection)
            {
                keywords.AddRange(keywordCollection.Value);
            }

            IKeywordProcessorProvider keywordProcessorProvider = (IKeywordProcessorProvider)ProviderFactory.Instance.CreateProvider<IKeywordProcessorProvider>(null);
            returnContainer.Tags = keywordProcessorProvider.GetTags(keywords).Take(5).ToList<string>();
            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}