// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentDetailsTests.cs

namespace CommandTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RestServiceV1.DataContracts;
    using Helper;
    using RestServiceV1;

    /// <summary>
    /// Get agent details tests
    /// </summary>
    [TestClass]
    public class GetAgentDetailsTests
    {
        /// <summary>
        /// Gets the agent details_ positive test.
        /// </summary>
        [TestMethod]
        public void GetAgentDetails_PositiveTest()
        {
            GetAgentDetailsRequestContainer requestContainer = new GetAgentDetailsRequestContainer() { AgentId = Guid.NewGuid().ToString(), ProviderName = "SqlTestProvider", UserId = Guid.NewGuid().ToString() };
            GetAgentDetailsReturnContainer returnContainer = CommandTestHelper.SendRequest<GetAgentDetailsRequestContainer, GetAgentDetailsReturnContainer>("GetAgentDetails", requestContainer);

            Assert.AreEqual(returnContainer.ReturnCode, ReturnCodes.C101, "Return codes.");
        }
    }
}
