// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = RequestContext.cs

namespace RestServiceV1.DataContracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Request context
    /// </summary>
    public class RequestContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext"/> class.
        /// </summary>
        /// <param name="baseCommunicationContainer">The base communication container.</param>
        public RequestContext(BaseRequestContainer baseCommunicationContainer)
        {
            this.RequestCorelationId = Guid.NewGuid();
            this.InParam = baseCommunicationContainer;
        }

        /// <summary>
        /// Gets or sets the in parameter.
        /// </summary>
        /// <value>
        /// The in parameter.
        /// </value>
        public BaseRequestContainer InParam { get; set; }

        /// <summary>
        /// Gets or sets the request corelation identifier.
        /// </summary>
        /// <value>
        /// The request corelation identifier.
        /// </value>
        public Guid RequestCorelationId { get; set; }
    }
}