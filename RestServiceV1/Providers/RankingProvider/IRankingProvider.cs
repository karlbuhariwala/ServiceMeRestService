// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = IRankingProvider.cs

namespace RestServiceV1.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for ranking provider
    /// </summary>
    interface IRankingProvider : IProvider
    {
        /// <summary>
        /// Sorts the by rank.
        /// </summary>
        /// <param name="agents">The agents.</param>
        void SortByRank(List<UserProfile> agents);
    }
}
