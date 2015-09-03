// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = INlpProvider.cs

namespace RestServiceV1.Providers
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for the nlp provider
    /// </summary>
    interface INlpProvider : IProvider
    {
        /// <summary>
        /// Gets the relevant terms.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>IDictionary of types of tokens and values</returns>
        IDictionary<string, IEnumerable<string>> GetRelevantTerms(string text);
    }
}
