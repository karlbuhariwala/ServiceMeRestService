// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = AgentContextCaseDetails.cs

namespace RestServiceV1.DataContracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Contextual Case Details
    /// </summary>
    public class ContextualCaseDetails
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the agent identifier.
        /// </summary>
        /// <value>
        /// The agent identifier.
        /// </value>
        public string AgentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the agent.
        /// </summary>
        /// <value>
        /// The name of the agen.
        /// </value>
        public string AgentName { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the contact preference.
        /// </summary>
        /// <value>
        /// The contact preference.
        /// </value>
        public List<string> ContactPreference { get; set; }

        /// <summary>
        /// Gets or sets the quote.
        /// </summary>
        /// <value>
        /// The quote.
        /// </value>
        public string Quote { get; set; }

        /// <summary>
        /// Gets or sets the timeline.
        /// </summary>
        /// <value>
        /// The timeline.
        /// </value>
        public string Timeline { get; set; }

        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        /// <value>
        /// The payment status.
        /// </value>
        public string PaymentStatus { get; set; }

        /// <summary>
        /// Gets or sets the user notes.
        /// </summary>
        /// <value>
        /// The user notes.
        /// </value>
        public string UserNotes { get; set; }

        /// <summary>
        /// Gets or sets the agent notes.
        /// </summary>
        /// <value>
        /// The agent notes.
        /// </value>
        public string AgentNotes { get; set; }
    }
}