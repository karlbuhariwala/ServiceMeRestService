// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = GoogleApiGeocodeContainer.cs

namespace RestServiceV1.DataContracts.InApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Web;

    /// <summary>
    /// Google api geocode container
    /// </summary>
    [DataContract]
    public class GoogleApiGeocodeContainer
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        [DataMember(Name = "results")]
        public ResultContainer[] Results { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [DataMember(Name = "status")]
        public string Status { get; set; }
    }

    /// <summary>
    /// Result container
    /// </summary>
    [DataContract]
    public class ResultContainer
    {
        /// <summary>
        /// Gets or sets the formatted address.
        /// </summary>
        /// <value>
        /// The formatted address.
        /// </value>
        [DataMember(Name = "formatted_address")]
        public string FormattedAddress { get; set; }

        /// <summary>
        /// Gets or sets the geometry.
        /// </summary>
        /// <value>
        /// The geometry.
        /// </value>
        [DataMember(Name = "geometry")]
        public GeometryContainer Geometry { get; set; }
    }

    /// <summary>
    /// Geometry container
    /// </summary>
    [DataContract]
    public class GeometryContainer
    {
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [DataMember(Name = "location")]
        public LocationContainer Location { get; set; }

        /// <summary>
        /// Gets or sets the type of the location.
        /// </summary>
        /// <value>
        /// The type of the location.
        /// </value>
        [DataMember(Name = "location_type")]
        public string LocationType { get; set; }
    }

    /// <summary>
    /// Location container
    /// </summary>
    [DataContract]
    public class LocationContainer
    {
        /// <summary>
        /// Gets or sets the lattitude.
        /// </summary>
        /// <value>
        /// The lattitude.
        /// </value>
        [DataMember(Name = "lat")]
        public double Lattitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        [DataMember(Name = "lng")]
        public double Longitude { get; set; }
    }
}