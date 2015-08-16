// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = ISqlProvider.cs

namespace RestServiceV1.Providers
{
    using System.Data;

    /// <summary>
    /// Interface for the SqlProvider
    /// </summary>
    public interface ISqlProvider : IProvider
    {
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>DataSet of the query</returns>
        DataSet ExecuteQuery(string query);
    }
}
