// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = UpdateUserProfileCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;

    /// <summary>
    /// Command to update the user profile of the user
    /// </summary>
    public class UpdateUserProfileCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>BaseReturnContainer object</returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            UpdateProfileRequestContainer requestContainer = context.InParam as UpdateProfileRequestContainer;
            UpdateProfileReturnContainer returnContainer = new UpdateProfileReturnContainer();

            // Todo: Complete after SQL or make hard coded data
            returnContainer.ReturnCode = ReturnCodes.C101;

            return returnContainer;
        }
    }
}