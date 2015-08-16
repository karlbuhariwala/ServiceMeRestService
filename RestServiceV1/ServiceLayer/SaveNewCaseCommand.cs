// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = SaveNewCaseCommand.cs

namespace RestServiceV1.ServiceLayer
{
    using RestServiceV1.DataContracts;

    /// <summary>
    /// Command to save a new case from the user
    /// </summary>
    public class SaveNewCaseCommand : BaseCommand
    {
        /// <summary>
        /// Called when [execute].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override BaseReturnContainer OnExecute(RequestContext context)
        {
            SaveNewCaseRequestContainer requestContainer = context.InParam as SaveNewCaseRequestContainer;
            SaveNewCaseReturnContainer returnContainer = new SaveNewCaseReturnContainer();

            returnContainer.ReturnCode = ReturnCodes.C101;

            return returnContainer;
        }
    }
}