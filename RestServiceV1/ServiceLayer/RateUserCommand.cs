// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = RateUserCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using DataContracts;
    using Providers;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;

    public class RateUserCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            RateUserRequestContainer requestContainer = context.InParam as RateUserRequestContainer;
            RateUserReturnContainer returnContainer = new RateUserReturnContainer();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@deleted", false } };
            parameters.Add("@userId", requestContainer.UserId);
            parameters.Add("@caseId", requestContainer.CaseId);

            DataSet result = sqlProvider.ExecuteQuery(SqlQueries.GetUserRatingsFromContextualInfoQuery(requestContainer.IsAgent), parameters);
            if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
            {
                DataRow row = result.Tables[0].Rows[0];

                int contextualDetailsRatingCount;
                int.TryParse(row["ContextualDetailsRatingCount"].ToString(), out contextualDetailsRatingCount);

                if (contextualDetailsRatingCount > 1)
                {
                    returnContainer.ReturnCode = ReturnCodes.C102;
                    return returnContainer;
                }

                double rating;
                double.TryParse(row["Rating"].ToString(), out rating);

                int userInfoTableRatingCount;
                int.TryParse(row["UserInfoTableRatingCount"].ToString(), out userInfoTableRatingCount);

                double newRating = ((rating * userInfoTableRatingCount) + requestContainer.Rating) / (double)(userInfoTableRatingCount + 1);
                userInfoTableRatingCount += 1;
                contextualDetailsRatingCount += 1;

                parameters.Clear();
                parameters.Add("@userId", requestContainer.UserId);
                parameters.Add("@rating", newRating);
                parameters.Add("@ratingCount", userInfoTableRatingCount);
                sqlProvider.ExecuteQuery(SqlQueries.UpdateUserInfoWithRatingQuery(requestContainer.IsAgent), parameters);

                parameters.Clear();
                parameters.Add("@caseId", requestContainer.CaseId);
                parameters.Add("@userId", requestContainer.UserId);
                parameters.Add("@rating", requestContainer.Rating);
                parameters.Add("@ratingCount", contextualDetailsRatingCount);
                sqlProvider.ExecuteQuery(SqlQueries.UpdateContextualDetailsWithRatingQuery(requestContainer.IsAgent), parameters);
                returnContainer.ReturnCode = ReturnCodes.C101;
            }
            else
            {
                returnContainer.ReturnCode = ReturnCodes.C001;
            }

            return returnContainer;
        }
    }
}