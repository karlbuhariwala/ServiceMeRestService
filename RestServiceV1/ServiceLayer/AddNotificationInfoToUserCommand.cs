// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = AddNotificationInfoToUserCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using DataContracts;
    using Providers;
    using System.Collections.Generic;

    /// <summary>
    /// Add notification info to user command
    /// </summary>
    public class AddNotificationInfoToUserCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            AddNotificationInfoToUserRequestContainer requestContainer = context.InParam as AddNotificationInfoToUserRequestContainer;
            AddNotificationInfoToUserReturnContainer returnContainer = new AddNotificationInfoToUserReturnContainer();

            ISqlProvider sqlProvider = (ISqlProvider)ProviderFactory.Instance.CreateProvider<ISqlProvider>(requestContainer.ProviderName);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@userId", requestContainer.UserId);
            parameters.Add("@notificationToken", requestContainer.NotificationToken);
            sqlProvider.ExecuteQuery(SqlQueries.UpdateNotificationTokenForUser, parameters);

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}