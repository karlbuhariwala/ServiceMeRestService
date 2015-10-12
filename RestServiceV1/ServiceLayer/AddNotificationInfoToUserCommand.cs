// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = AddNotificationInfoToUserCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using DataContracts;

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

            returnContainer.ReturnCode = ReturnCodes.C101;
            return returnContainer;
        }
    }
}