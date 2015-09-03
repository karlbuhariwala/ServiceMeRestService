// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = IKeywordProcessorProvider.cs

namespace RestServiceV1.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for keyword processor provider
    /// </summary>
    interface IKeywordProcessorProvider : IProvider
    {
        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <param name="keywords">The keywords.</param>
        /// <returns>IEnumerable of tags</returns>
        IEnumerable<string> GetTags(IEnumerable<string> keywords);
    }
}
