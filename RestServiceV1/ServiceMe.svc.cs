﻿// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = ServiceMe.svc.cs

namespace RestServiceV1
{
    using RestServiceV1.DataContracts;
    using RestServiceV1.ServiceLayer;
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Class for the implementation of the IServiceMe interface
    /// </summary>
    public class ServiceMe : IServiceMe
    {
        /// <summary>
        /// Gets the test data.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Test data string
        /// </returns>
        string IServiceMe.GetTestData(string id)
        {
            return "The returned data" + id;
        }

        /// <summary>
        /// Posts the test data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        TestDataClass IServiceMe.PostTestData(TestDataClass data)
        {
            data.Name = "Buhariwala";
            return data;
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Create new user container
        /// </returns>
        CreateNewUserReturnContainer IServiceMe.CreateUser(CreateNewUserRequestContainer contents)
        {
            try
            {
                return (CreateNewUserReturnContainer)this.RunCommand(new CreateNewUserCommand(), contents);
            }
            catch (Exception)
            {
                return new CreateNewUserReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Validates the device.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Device validation container
        /// </returns>
        DeviceValidationReturnContainer IServiceMe.ValidateDevice(DeviceValidationRequestContainer contents)
        {
            try
            {
                return (DeviceValidationReturnContainer)this.RunCommand(new DeviceValidationCommand(), contents);
            }
            catch (Exception)
            {
                return new DeviceValidationReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get profile container
        /// </returns>
        GetProfileReturnContrainer IServiceMe.GetProfile(GetProfileRequestContainer contents)
        {
            try
            {
                return (GetProfileReturnContrainer)this.RunCommand(new GetProfileCommand(), contents);
            }
            catch (Exception)
            {
                return new GetProfileReturnContrainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Updates the profile.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Update profile container
        /// </returns>
        UpdateProfileReturnContainer IServiceMe.CreateUpdateProfile(UpdateProfileRequestContainer contents)
        {
            try
            {
                return (UpdateProfileReturnContainer)this.RunCommand(new UpdateUserProfileCommand(), contents);
            }
            catch (Exception)
            {
                return new UpdateProfileReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get tags return container
        /// </returns>
        GetTagsReturnContainer IServiceMe.GetTags(GetTagsRequestContainer contents)
        {
            try
            {
                return (GetTagsReturnContainer)this.RunCommand(new GetTagsCommand(), contents);
            }
            catch (Exception)
            {
                return new GetTagsReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the recommended agents.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get recommended agents cotnainer
        /// </returns>
        GetRecommendedAgentsReturnContainer IServiceMe.GetRecommendedAgents(GetRecommendedAgentsRequestContainer contents)
        {
            try
            {
                return (GetRecommendedAgentsReturnContainer)this.RunCommand(new GetRecommendedAgentsCommand(), contents);
            }
            catch (Exception)
            {
                return new GetRecommendedAgentsReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the agents for automatic complete.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get agents for autocomplete container
        /// </returns>
        GetAgentsForAutoCompleteReturnContainer IServiceMe.GetAgentsForAutoComplete(GetAgentsForAutoCompleteRequestContainer contents)
        {
            try
            {
                return (GetAgentsForAutoCompleteReturnContainer)this.RunCommand(new GetAgentsForAutoCompleteCommand(), contents);
            }
            catch (Exception)
            {
                return new GetAgentsForAutoCompleteReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the tags for automatic complete.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get tags for autocomplete container
        /// </returns>
        GetTagsForAutoCompleteReturnContainer IServiceMe.GetTagsForAutoComplete(GetTagsForAutoCompleteRequestContainer contents)
        {
            try
            {
                return (GetTagsForAutoCompleteReturnContainer)this.RunCommand(new GetTagsForAutoCompleteCommand(), contents);
            }
            catch (Exception)
            {
                return new GetTagsForAutoCompleteReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the agent details.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get agent details container
        /// </returns>
        GetAgentDetailsReturnContainer IServiceMe.GetAgentDetails(GetAgentDetailsRequestContainer contents)
        {
            try
            {
                return (GetAgentDetailsReturnContainer)this.RunCommand(new GetAgentDetailsCommand(), contents);
            }
            catch (Exception)
            {
                return new GetAgentDetailsReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Saves the new case.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Save new case container
        /// </returns>
        SaveNewCaseReturnContainer IServiceMe.SaveNewCase(SaveNewCaseRequestContainer contents)
        {
            try
            {
                return (SaveNewCaseReturnContainer)this.RunCommand(new SaveNewCaseCommand(), contents);
            }
            catch (Exception)
            {
                return new SaveNewCaseReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the user cases.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get user cases container
        /// </returns>
        GetUserCasesReturnContainer IServiceMe.GetUserCases(GetUserCasesRequestContainer contents)
        {
            try
            {
                return (GetUserCasesReturnContainer)this.RunCommand(new GetUserCasesCommand(), contents);
            }
            catch (Exception)
            {
                return new GetUserCasesReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the user case detail.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get user case detail return container
        /// </returns>
        GetUserCaseDetailReturnContainer IServiceMe.GetUserCaseDetail(GetUserCaseDetailRequestContainer contents)
        {
            try
            {
                return (GetUserCaseDetailReturnContainer)this.RunCommand(new GetUserCaseDetailCommand(), contents);
            }
            catch (Exception)
            {
                return new GetUserCaseDetailReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the agents for case.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get agents for the case return container
        /// </returns>
        GetAgentsForCaseReturnContainer IServiceMe.GetAgentsForCase(GetAgentsForCaseRequestContainer contents)
        {
            try
            {
                return (GetAgentsForCaseReturnContainer)this.RunCommand(new GetAgentsForCaseCommand(), contents);
            }
            catch (Exception)
            {
                return new GetAgentsForCaseReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the agent context case details.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get agent context case details return container
        /// </returns>
        GetAgentContextCaseDetailsReturnContainer IServiceMe.GetAgentContextCaseDetails(GetAgentContextCaseDetailsRequestContainer contents)
        {
            try
            {
                return (GetAgentContextCaseDetailsReturnContainer)this.RunCommand(new GetAgentContextCaseDetailsCommand(), contents);
            }
            catch (Exception)
            {
                return new GetAgentContextCaseDetailsReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Sets the agent tags.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Add agent tags return container
        /// </returns>
        AddAgentTagsReturnContainer IServiceMe.SetAgentTags(AddAgentTagsRequestContainer contents)
        {
            try
            {
                return (AddAgentTagsReturnContainer)this.RunCommand(new AddAgentTagsCommand(), contents);
            }
            catch (Exception)
            {
                return new AddAgentTagsReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the agent cases.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get agent cases request container
        /// </returns>
        GetAgentCasesReturnContainer IServiceMe.GetAgentCases(GetAgentCasesRequestContainer contents)
        {
            try
            {
                return (GetAgentCasesReturnContainer)this.RunCommand(new GetAgentCasesCommand(), contents);
            }
            catch (Exception)
            {
                return new GetAgentCasesReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the agent case details.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get agent case details return container
        /// </returns>
        GetAgentCaseDetailsReturnContainer IServiceMe.GetAgentCaseDetails(GetAgentCaseDetailsRequestContainer contents)
        {
            try
            {
                return (GetAgentCaseDetailsReturnContainer)this.RunCommand(new GetAgentCaseDetailsCommand(), contents);
            }
            catch (Exception)
            {
                return new GetAgentCaseDetailsReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the popular request.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get popular requests return container
        /// </returns>
        GetPopularRequestsReturnContainer IServiceMe.GetPopularRequest(GetPopularRequestsRequestContainer contents)
        {
            try
            {
                return (GetPopularRequestsReturnContainer)this.RunCommand(new GetPopularRequestsCommand(), contents);
            }
            catch (Exception)
            {
                return new GetPopularRequestsReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Updates the user notification information.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Add notification info to user return container
        /// </returns>
        AddNotificationInfoToUserReturnContainer IServiceMe.UpdateUserNotificationInfo(AddNotificationInfoToUserRequestContainer contents)
        {
            try
            {
                return (AddNotificationInfoToUserReturnContainer)this.RunCommand(new AddNotificationInfoToUserCommand(), contents);
            }
            catch (Exception)
            {
                return new AddNotificationInfoToUserReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the chat room details.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get chat room details return container
        /// </returns>
        GetChatRoomDetailsReturnContainer IServiceMe.GetChatRoomDetails(GetChatRoomDetailsRequestContainer contents)
        {
            try
            {
                return (GetChatRoomDetailsReturnContainer)this.RunCommand(new GetChatRoomDetailsCommand(), contents);
            }
            catch (Exception)
            {
                return new GetChatRoomDetailsReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Sends the chat message.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Send chat message return container
        /// </returns>
        SendChatMessageReturnContainer IServiceMe.SendChatMessage(SendChatMessageRequestContainer contents)
        {
            try
            {
                return (SendChatMessageReturnContainer)this.RunCommand(new SendChatMessageCommand(), contents);
            }
            catch (Exception)
            {
                return new SendChatMessageReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Assigns the agent to case.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Assigned case return container
        /// </returns>
        AssignCaseReturnContainer IServiceMe.AssignAgentToCase(AssignCaseRequestContainer contents)
        {
            try
            {
                return (AssignCaseReturnContainer)this.RunCommand(new AssignAgentToCaseCommand(), contents);
            }
            catch (Exception)
            {
                return new AssignCaseReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Gets the user tags.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Get user tags return container
        /// </returns>
        GetUserTagsReturnContainer IServiceMe.GetUserTags(GetUserTagsRequestContainer contents)
        {
            try
            {
                return (GetUserTagsReturnContainer)this.RunCommand(new GetUserTagsCommand(), contents);
            }
            catch (Exception)
            {
                return new GetUserTagsReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Rates the user.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns>
        /// Rate user return container
        /// </returns>
        RateUserReturnContainer IServiceMe.RateUser(RateUserRequestContainer contents)
        {
            try
            {
                return (RateUserReturnContainer)this.RunCommand(new RateUserCommand(), contents);
            }
            catch (Exception)
            {
                return new RateUserReturnContainer() { ReturnCode = ReturnCodes.GenericExceptionErrorCode };
            }
        }

        /// <summary>
        /// Runs the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="contents">The contents.</param>
        /// <returns>The result of the command</returns>
        private BaseReturnContainer RunCommand(BaseCommand command, BaseRequestContainer contents)
        {
            RequestContext context = new RequestContext(contents);
            if (command.OnValidate(context))
            {
                BaseReturnContainer returnContainer = command.OnExecute(context);
                Debug.Assert(!string.IsNullOrEmpty(returnContainer.ReturnCode));
                return returnContainer;
            }

            // Todo: what happens when validate fails?
            return null;
        }
    }
}
