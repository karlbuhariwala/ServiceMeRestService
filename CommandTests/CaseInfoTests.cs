// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GetAgentDetailsTests.cs

namespace CommandTests
{
    using Helper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RestServiceV1;
    using RestServiceV1.DataContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Case info tests
    /// </summary>
    [TestClass]
    public class CaseInfoTests
    {
        /// <summary>
        /// Saves the new case_ positive test.
        /// </summary>
        [TestMethod]
        public void SaveNewCase_PositiveTest()
        {
            CaseDetails caseDetails = new CaseDetails();
            caseDetails.UserId = Guid.NewGuid().ToString();
            caseDetails.UserName = "Ted Garyovich";
            caseDetails.Title = "I would like to host a party";
            caseDetails.ContactPreference = new List<string>()
            {
                "Chat",
                "Email",
            };

            caseDetails.Tags = new List<string>()
            {
                "PartyPlanning",
            };

            caseDetails.RequestDetails = "My birthday is on the 25 of may and I would like a party";

            SaveNewCaseRequestContainer requestContainer = new SaveNewCaseRequestContainer() { CaseInfo = caseDetails, ProviderName = "SqlProvider"};
            SaveNewCaseReturnContainer returnContainer = CommandTestHelper.SendRequest<SaveNewCaseRequestContainer, SaveNewCaseReturnContainer>("SaveNewCase", requestContainer);

            Assert.AreEqual(returnContainer.ReturnCode, ReturnCodes.C101, "Return codes.");
        }

        /// <summary>
        /// Gets the user cases_ positive test.
        /// </summary>
        [TestMethod]
        public void GetUserCases_PositiveTest()
        {
            //GetUserCasesRequestContainer requestContainer = new GetUserCasesRequestContainer() { UserId = Guid.NewGuid().ToString(), ProviderName = "SqlProvider" };
            GetUserCasesRequestContainer requestContainer = new GetUserCasesRequestContainer() { UserId = "F7CAE2D5-A625-4CDA-A9A1-8F57926867A0", ProviderName = "SqlProvider" };
            GetUserCasesReturnContainer returnContainer = CommandTestHelper.SendRequest<GetUserCasesRequestContainer, GetUserCasesReturnContainer>("GetUserCases", requestContainer);

            Assert.AreEqual(returnContainer.ReturnCode, ReturnCodes.C101, "Return codes.");
        }
    }
}
