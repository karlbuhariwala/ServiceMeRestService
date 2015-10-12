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

        /// <summary>
        /// Gets the user cases.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get user cases container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetUserCases")]
        GetUserCasesReturnContainer GetUserCases(GetUserCasesRequestContainer contents);

        /// <summary>
        /// Gets the user case detail.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get user case detail return container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetUserCaseDetail")]
        GetUserCaseDetailReturnContainer GetUserCaseDetail(GetUserCaseDetailRequestContainer contents);

        /// <summary>
        /// Gets the agents for case.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get agents for the case return container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetAgentsForCase")]
        GetAgentsForCaseReturnContainer GetAgentsForCase(GetAgentsForCaseRequestContainer contents);

        /// <summary>
        /// Gets the agent context case details.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get agent context case details return container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetAgentContextCaseDetails")]
        GetAgentContextCaseDetailsReturnContainer GetAgentContextCaseDetails(GetAgentContextCaseDetailsRequestContainer contents);

        /// <summary>
        /// Sets the agent tags.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Add agent tags return container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "SetAgentTags")]
        AddAgentTagsReturnContainer SetAgentTags(AddAgentTagsRequestContainer contents);

        /// <summary>
        /// Gets the agent cases.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get agent cases request container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetAgentCases")]
        GetAgentCasesReturnContainer GetAgentCases(GetAgentCasesRequestContainer contents);

        /// <summary>
        /// Gets the agent case details.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get agent case details return container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetAgentCaseDetails")]
        GetAgentCaseDetailsReturnContainer GetAgentCaseDetails(GetAgentCaseDetailsRequestContainer contents);

        /// <summary>
        /// Gets the popular request.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get popular requests return container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetPopularRequest")]
        GetPopularRequestsReturnContainer GetPopularRequest(GetPopularRequestsRequestContainer contents);

        /// <summary>
        /// Updates the user notification information.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Add notification info to user return container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "UpdateUserNotificationInfo")]
        AddNotificationInfoToUserReturnContainer UpdateUserNotificationInfo(AddNotificationInfoToUserRequestContainer contents);

        /// <summary>
        /// Gets the chat room details.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>Get chat room details return container</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetChatRoomDetails")]
        GetChatRoomDetailsReturnContainer GetChatRoomDetails(GetChatRoomDetailsRequestContainer contents);
    }
}
