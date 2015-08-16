// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = IServiceMe.cs

namespace RestServiceV1
{
    using RestServiceV1.DataContracts;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    /// <summary>
    /// Interface for the ServiceMe rest service
    /// </summary>
    [ServiceContract]
    public interface IServiceMe
    {
        /// <summary>
        /// Gets the test data.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Test data string</returns>
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetTestData/{id}")]
        string GetTestData(string id);

        /// <summary>
        /// Posts the test data.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Test data class</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "PostTestData")]
        TestDataClass PostTestData(TestDataClass contents);

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Create new user container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "CreateUser")]
        CreateNewUserReturnContainer CreateUser(CreateNewUserRequestContainer contents);

        /// <summary>
        /// Validates the device.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Device validation container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "ValidateDevice")]
        DeviceValidationReturnContainer ValidateDevice(DeviceValidationRequestContainer contents);

        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get profile container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetProfile")]
        GetProfileReturnContrainer GetProfile(GetProfileRequestContainer contents);

        /// <summary>
        /// Updates the profile.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Update profile container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "CreateUpdateProfile")]
        UpdateProfileReturnContainer CreateUpdateProfile(UpdateProfileRequestContainer contents);

        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get tags return container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetTags")]
        GetTagsReturnContainer GetTags(GetTagsRequestContainer contents);

        /// <summary>
        /// Gets the recommended agents.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get recommended agents cotnainer</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetRecommendedAgents")]
        GetRecommendedAgentsReturnContainer GetRecommendedAgents(GetRecommendedAgentsRequestContainer contents);

        /// <summary>
        /// Gets the agents for automatic complete.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get agents for autocomplete container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetAgentsForAutoComplete")]
        GetAgentsForAutoCompleteReturnContainer GetAgentsForAutoComplete(GetAgentsForAutoCompleteRequestContainer contents);

        /// <summary>
        /// Gets the tags for automatic complete.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get tags for autocomplete container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetTagsForAutoComplete")]
        GetTagsForAutoCompleteReturnContainer GetTagsForAutoComplete(GetTagsForAutoCompleteRequestContainer contents);

        /// <summary>
        /// Gets the agent details.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get agent details container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetAgentDetails")]
        GetAgentDetailsReturnContainer GetAgentDetails(GetAgentDetailsRequestContainer contents);

        /// <summary>
        /// Saves the new case.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Save new case container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "SaveNewCase")]
        SaveNewCaseReturnContainer SaveNewCase(SaveNewCaseRequestContainer contents);
    }
}
