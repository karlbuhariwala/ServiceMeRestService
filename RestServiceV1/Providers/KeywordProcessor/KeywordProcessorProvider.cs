// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = KeywordProcessorProvider.cs

namespace RestServiceV1.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Keyword process provider
    /// </summary>
    public class KeywordProcessorProvider : IKeywordProcessorProvider
    {
        /// <summary>
        /// The keyword tag map
        /// </summary>
        private static Dictionary<string, List<string>> keywordTagMap;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeywordProcessorProvider"/> class.
        /// </summary>
        public KeywordProcessorProvider()
        {
            if (KeywordProcessorProvider.keywordTagMap == null)
            {
                KeywordProcessorProvider.keywordTagMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
                this.InitializeKeywordTagMap(KeywordProcessorProvider.keywordTagMap);
            }
        }

        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <param name="keywords">The keywords.</param>
        /// <returns></returns>
        IEnumerable<string> IKeywordProcessorProvider.GetTags(IEnumerable<string> keywords)
        {
            Dictionary<string, int> tagScore = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var keyword in keywords)
            {
                if (KeywordProcessorProvider.keywordTagMap.ContainsKey(keyword))
                {
                    foreach (var tag in KeywordProcessorProvider.keywordTagMap[keyword])
                    {
                        if (!tagScore.ContainsKey(tag))
                        {
                            tagScore.Add(tag, 0);
                        }

                        tagScore[tag] += 1;
                    }
                }
            }

            return tagScore.OrderByDescending(x => x.Value).Select(y => y.Key).ToList();
        }

        /// <summary>
        /// Initializes the keyword tag map.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        private void InitializeKeywordTagMap(Dictionary<string, List<string>> dictionary)
        {
            // Todo: Remove the param
            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(null);
            DataSet result = sqlProvider.ExecuteQuery(SqlQueries.GetTagKeywordMap, new Dictionary<string, object>() { { "@deleted", 0 } });

            if (result.Tables.Count == 1 && result.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in result.Tables[0].Rows)
                {
                    string tag = row["Tag"].ToString();
                    var keywords = row["Keyword"].ToString().Split(new string[] { Constants.QuerySeparator }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    foreach (string keyword in keywords)
                    {
                        List<string> tags;
                        if (dictionary.ContainsKey(keyword))
                        {
                            tags = dictionary[keyword];
                        }
                        else
                        {
                            tags = new List<string>();
                            dictionary.Add(keyword, tags);
                        }

                        tags.Add(tag);
                    }
                }
            }
            else
            {
                // Todo: Log
            }
        }
    }
}