// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = UserProfile.cs

namespace RestServiceV1
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// User profile
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [DataMember(Name = "userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is verified.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is verified; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "isVerified")]
        public bool IsVerified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is email verified.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is email verified; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "isEmailVerified")]
        public bool IsEmailVerified { get; set; }

        /// <summary>
        /// Gets or sets the contact preference.
        /// </summary>
        /// <value>
        /// The contact preference.
        /// </value>
        [DataMember(Name = "contactPreference")]
        public List<string> ContactPreference { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [DataMember(Name = "emailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// 
        /// Note: Need a better data structure
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [DataMember(Name = "address")]
        public AddressContainer Address { get; set; }

        /// <summary>
        /// Gets or sets the payment details.
        /// 
        /// Note: need secure string and a better data structure
        /// </summary>
        /// <value>
        /// The payment details.
        /// </value>
        [DataMember(Name = "paymentDetails")]
        public string PaymentDetails { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is agent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is agent; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "isAgent")]
        public bool IsAgent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is manager.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is manager; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "isManager")]
        public bool IsManager { get; set; }

        /// <summary>
        /// Gets or sets the landing page.
        /// </summary>
        /// <value>
        /// The landing page.
        /// </value>
        [DataMember(Name = "landingPage")]
        public int LandingPage { get; set; }

        /// <summary>
        /// Gets or sets the push notification URI.
        /// </summary>
        /// <value>
        /// The push notification URI.
        /// </value>
        [DataMember(Name = "pushNotificationUri")]
        public string PushNotificationUri { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        [DataMember(Name = "agentRating")]
        public double AgentRating { get; set; }

        /// <summary>
        /// Gets or sets the user rating.
        /// </summary>
        /// <value>
        /// The user rating.
        /// </value>
        [DataMember(Name = "userRating")]
        public double UserRating { get; set; }

        /// <summary>
        /// Gets or sets the number of ratings.
        /// </summary>
        /// <value>
        /// The number of ratings.
        /// </value>
        [DataMember(Name = "agentRatingCount")]
        public int AgentRatingCount { get; set; }

        /// <summary>
        /// Gets or sets the agent positive rating count.
        /// </summary>
        /// <value>
        /// The agent positive rating count.
        /// </value>
        [DataMember(Name = "agentPositiveRatingCount")]
        public int AgentPositiveRatingCount { get; set; }

        /// <summary>
        /// Gets or sets the ci of 5 star rating.
        /// </summary>
        /// <value>
        /// The ci of5 star rating.
        /// </value>
        [DataMember(Name = "cIOf5StarRating")]
        public double CIOf5StarRating { get; set; }

        /// <summary>
        /// Gets or sets the user rating count.
        /// </summary>
        /// <value>
        /// The user rating count.
        /// </value>
        [DataMember(Name = "userRatingCount")]
        public int UserRatingCount { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the area of service.
        /// </summary>
        /// <value>
        /// The area of service.
        /// </value>
        [DataMember(Name = "areaOfService")]
        public double AreaOfService { get; set; }

        /// <summary>
        /// Gets or sets the favorite agents.
        /// 
        /// Note: Calculate limit
        /// </summary>
        /// <value>
        /// The favorite agents.
        /// </value>
        [DataMember(Name = "favoriteAgents")]
        public List<string> FavoriteAgents { get; set; }

        /// <summary>
        /// Gets or sets the user latitude.
        /// </summary>
        /// <value>
        /// The user latitude.
        /// </value>
        [DataMember(Name = "userLatitude")]
        public double UserLatitude { get; set; }

        /// <summary>
        /// Gets or sets the user longitude.
        /// </summary>
        /// <value>
        /// The user longitude.
        /// </value>
        [DataMember(Name = "userLongitude")]
        public double UserLongitude { get; set; }
    }
}