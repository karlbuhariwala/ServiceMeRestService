// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetProfileCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;
    using RestServiceV1.Providers;
    using System.Data;

    /// <summary>
    /// Command to get the profile of the user
    /// </summary>
    public class GetProfileCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            GetProfileRequestContainer requestContainer = context.InParam as GetProfileRequestContainer;
            GetProfileReturnContrainer returnContainer = new GetProfileReturnContrainer();

            // Todo: Optimize after writing query
            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            DataSet returnedData = sqlProvider.ExecuteQuery(SqlQueries.GetUserProfileQuery, null);
            if (returnedData.Tables[0].Rows.Count == 1)
            {
                DataRow row = returnedData.Tables[0].Rows[0];
                UserProfile userProfile = new UserProfile();
                userProfile.Name = row["Name"].ToString();
                /// addd more

                // Found user and returning it
                returnContainer.ReturnCode = ReturnCodes.C101;
                returnContainer.User = userProfile;
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