// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = RankingProvider.cs

namespace RestServiceV1.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Ranking provider class
    /// </summary>
    public class RankingProvider : IRankingProvider
    {
        /// <summary>
        /// The z score 95th percentile
        /// </summary>
        private const double ZScore95thPercentile = 1.96;

        /// <summary>
        /// Sorts the by rank.
        /// </summary>
        /// <param name="agents">The agents.</param>
        void IRankingProvider.SortByRank(List<UserProfile> agents)
        {
            foreach (UserProfile agent in agents)
            {
                agent.CIOf5StarRating = RankingProvider.CalculateCIOfAgent(agent);
            }

            agents.Sort(new AgentRatingComparer());
        }

        /// <summary>
        /// Calculates the ci of agent.
        /// </summary>
        /// <param name="agent">The agent.</param>
        private static double CalculateCIOfAgent(UserProfile agent)
        {
            double percetageOfPosRatings = 1.0 * agent.AgentPositiveRatingCount / agent.AgentRatingCount;
            double returnValue = (
                                    percetageOfPosRatings 
                                    + (RankingProvider.ZScore95thPercentile * RankingProvider.ZScore95thPercentile / (2 * agent.AgentRatingCount)) 
                                    - (RankingProvider.ZScore95thPercentile 
                                        * Math.Sqrt(
                                                        (percetageOfPosRatings * (1 - percetageOfPosRatings) 
                                                            + (RankingProvider.ZScore95thPercentile * RankingProvider.ZScore95thPercentile / (4 * agent.AgentRatingCount))
                                                        ) / agent.AgentRatingCount
                                                    )
                                      )
                                 ) / (1 + (RankingProvider.ZScore95thPercentile * RankingProvider.ZScore95thPercentile / agent.AgentRatingCount));
            return returnValue;
        }
    }

    /// <summary>
    /// Comparer for agent rating sorting
    /// </summary>
    public class AgentRatingComparer : IComparer<UserProfile>
    {
        /// <summary>
        /// Compares the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        int IComparer<UserProfile>.Compare(UserProfile x, UserProfile y)
        {
            if(x == null && y == null)
            {
                return 0;
            }
            else if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }
            else
            {
                if (x.CIOf5StarRating < y.CIOf5StarRating)
                {
                    return 1;
                }
                else if (x.CIOf5StarRating > y.CIOf5StarRating)
                {
                    return -1;
                }

                return 0;
            }
        }
    }
}