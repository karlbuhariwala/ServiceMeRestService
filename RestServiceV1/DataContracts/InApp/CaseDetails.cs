// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = CaseDetails.cs

namespace RestServiceV1.DataContracts
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Case details 
    /// </summary>
    public class CaseDetails
    {
        /// <summary>
        /// The created date
        /// </summary>
        [XmlIgnore]
        private DateTimeOffset createdDate;

        /// <summary>
        /// The resolved date
        /// </summary>
        [XmlIgnore]
        private DateTimeOffset resolvedDate;

        /// <summary>
        /// The closed date
        /// </summary>
        [XmlIgnore]
        private DateTimeOffset closedDate;

        /// <summary>
        /// The last update date time
        /// </summary>
        private DateTimeOffset lastUpdateDateTime;

        /// <summary>
        /// Gets or sets the case identifier.
        /// </summary>
        /// <value>
        /// The case identifier.
        /// </value>
        public string CaseId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the contact preference.
        /// </summary>
        /// <value>
        /// The contact preference.
        /// </value>
        public List<string> ContactPreference { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the request details.
        /// </summary>
        /// <value>
        /// The request details.
        /// </value>
        public string RequestDetails { get; set; }

        /// <summary>
        /// Gets or sets the budget.
        /// </summary>
        /// <value>
        /// The budget.
        /// </value>
        public int Budget { get; set; }

        /// <summary>
        /// Gets or sets the user address.
        /// </summary>
        /// <value>
        /// The user address.
        /// </value>
        public string UserAddress { get; set; }

        /// <summary>
        /// Gets or sets another address.
        /// </summary>
        /// <value>
        /// Another address.
        /// </value>
        public string AnotherAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [new message].
        /// 
        /// Note: Notification for a new message
        /// </summary>
        /// <value>
        ///   <c>true</c> if [new message]; otherwise, <c>false</c>.
        /// </value>
        public bool NewMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [new email].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [new email]; otherwise, <c>false</c>.
        /// </value>
        public bool NewEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [new phone call].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [new phone call]; otherwise, <c>false</c>.
        /// </value>
        public bool NewPhoneCall { get; set; }

        /// <summary>
        /// Gets or sets the assigned agent identifier.
        /// </summary>
        /// <value>
        /// The assigned agent identifier.
        /// </value>
        public string AssignedAgentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the assigned agent.
        /// </summary>
        /// <value>
        /// The name of the assigned agent.
        /// </value>
        public string AssignedAgentName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is enterprise tag.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is enterprise tag; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnterpriseTag { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is metadata complete.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is metadata complete; otherwise, <c>false</c>.
        /// </value>
        public bool IsMetadataComplete { get; set; }

        /// <summary>
        /// Gets or sets the last update date time.
        /// </summary>
        /// <value>
        /// The last update date time.
        /// </value>
        public DateTimeOffset LastUpdateDateTime
        {
            get
            {
                return this.lastUpdateDateTime;
            }
            set
            {
                this.lastUpdateDateTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the last update date time string.
        /// </summary>
        /// <value>
        /// The last update date time string.
        /// </value>
        public string LastUpdateDateTimeString // format: 2011-11-11T15:05:46.4733406+01:00
        {
            get
            {
                return this.lastUpdateDateTime.ToString(Constants.DateTimeFormat);
            }
            set
            {
                this.lastUpdateDateTime = DateTimeOffset.Parse(value);
            }
        }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        [XmlIgnore]
        public DateTimeOffset CreatedDate
        {
            get
            {
                return this.createdDate;
            }
            set
            {
                this.createdDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the resolved date.
        /// </summary>
        /// <value>
        /// The resolved date.
        /// </value>
        [XmlIgnore]
        public DateTimeOffset ResolvedDate
        {
            get
            {
                return this.resolvedDate;
            }
            set
            {
                this.resolvedDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the closed date.
        /// </summary>
        /// <value>
        /// The closed date.
        /// </value>
        [XmlIgnore]
        public DateTimeOffset ClosedDate
        {
            get
            {
                return this.closedDate;
            }
            set
            {
                this.closedDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the created date string.
        /// </summary>
        /// <value>
        /// The created date string.
        /// </value>
        [XmlElement("CreatedDate")]
        public string CreatedDateString // format: 2011-11-11T15:05:46.4733406+01:00
        {
            get
            {
                return this.createdDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            }
            set
            {
                this.createdDate = DateTimeOffset.Parse(value);
            }
        }

        /// <summary>
        /// Gets or sets the resolved date string.
        /// </summary>
        /// <value>
        /// The resolved date string.
        /// </value>
        [XmlElement("ResolvedDate")]
        public string ResolvedDateString // format: 2011-11-11T15:05:46.4733406+01:00
        {
            get
            {
                return this.resolvedDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            }
            set
            {
                this.resolvedDate = DateTimeOffset.Parse(value);
            }
        }

        /// <summary>
        /// Gets or sets the closed date string.
        /// </summary>
        /// <value>
        /// The closed date string.
        /// </value>
        [XmlElement("ClosedDate")]
        public string ClosedDateString // format: 2011-11-11T15:05:46.4733406+01:00
        {
            get
            {
                return this.closedDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            }
            set
            {
                this.closedDate = DateTimeOffset.Parse(value);
            }
        }
    }
}