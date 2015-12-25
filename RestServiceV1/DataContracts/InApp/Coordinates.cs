// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = Coordinates.cs

namespace RestServiceV1.DataContracts.InApp
{
    /// <summary>
    /// Coordinates
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> class.
        /// </summary>
        /// <param name="userLatitude">The user latitude.</param>
        /// <param name="userLongitude">The user longitude.</param>
        /// <param name="isRadians">if set to <c>true</c> [is radians].</param>
        public Coordinates(double userLatitude, double userLongitude, bool isRadians = false)
        {
            this.Latitude = userLatitude;
            this.Longitude = userLongitude;
            this.IsRadians = isRadians;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> class.
        /// </summary>
        /// <param name="isRadians">if set to <c>true</c> [is radians].</param>
        public Coordinates (bool isRadians = false)
        {
            this.IsRadians = isRadians;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is radians.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is radians; otherwise, <c>false</c>.
        /// </value>
        public bool IsRadians { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public double Longitude { get; set; }

        /// <summary>
        /// Converts to radians.
        /// </summary>
        public void ConvertToRadians ()
        {
            this.Latitude = this.Latitude * System.Math.PI / 180.0;
            this.Longitude = this.Longitude * System.Math.PI / 180.0;
            this.IsRadians = true;
        }

        /// <summary>
        /// Converts to degrees.
        /// </summary>
        public void ConvertToDegrees()
        {
            this.Latitude = this.Latitude * 180.0 / System.Math.PI;
            this.Longitude = this.Longitude * 180.0 / System.Math.PI;
            this.IsRadians = false;
        }
    }
}