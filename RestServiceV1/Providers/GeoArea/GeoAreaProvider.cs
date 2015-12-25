// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = IGeoAreaProvider.cs

namespace RestServiceV1.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using RestServiceV1.DataContracts.InApp;

    /// <summary>
    /// Geo area provider
    /// </summary>
    /// <seealso cref="RestServiceV1.Providers.IGeoAreaProvider" />
    public class GeoAreaProvider : IGeoAreaProvider
    {
        /// <summary>
        /// The radius of earth
        /// </summary>
        private const double RadiusOfEarth = 6371.0;

        /// <summary>
        /// Gets the boundary.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="distanceInKm">The distance in km.</param>
        /// <param name="topLeft">The top left.</param>
        /// <param name="bottomRight">The bottom right.</param>
        void IGeoAreaProvider.GetBoundary(Coordinates point, double distanceInKm, out Coordinates topLeft, out Coordinates bottomRight)
        {
            if (!point.IsRadians)
            {
                point.ConvertToRadians();
            }

            double bearing = 0;
            Coordinates top = GeoAreaProvider.GetPoint(point, distanceInKm, bearing);

            bearing = Math.PI / 2;
            Coordinates right = GeoAreaProvider.GetPoint(point, distanceInKm, bearing);

            bearing = Math.PI;
            Coordinates bottom = GeoAreaProvider.GetPoint(point, distanceInKm, bearing);

            bearing = Math.PI * 3 / 2;
            Coordinates left = GeoAreaProvider.GetPoint(point, distanceInKm, bearing);

            topLeft = new Coordinates(true);
            bottomRight = new Coordinates(true);

            topLeft.Latitude = top.Latitude;
            topLeft.Longitude = left.Longitude;

            bottomRight.Latitude = bottom.Latitude;
            bottomRight.Longitude = right.Longitude;

            topLeft.ConvertToDegrees();
            bottomRight.ConvertToDegrees();
        }

        /// <summary>
        /// Gets the point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="distanceInKm">The distance in km.</param>
        /// <param name="bearing">The bearing.</param>
        /// <returns>New coordinates</returns>
        private static Coordinates GetPoint(Coordinates point, double distanceInKm, double bearing)
        {
            Coordinates coordinateToReturn = new Coordinates(true);
            coordinateToReturn.Latitude = Math.Asin(Math.Sin(point.Latitude) * Math.Cos(distanceInKm / GeoAreaProvider.RadiusOfEarth) + Math.Cos(point.Latitude) * Math.Sin(distanceInKm / GeoAreaProvider.RadiusOfEarth) * Math.Cos(bearing));
            coordinateToReturn.Longitude = point.Longitude + Math.Atan2(Math.Sin(bearing) * Math.Sin(distanceInKm / GeoAreaProvider.RadiusOfEarth) * Math.Cos(point.Latitude), Math.Cos(distanceInKm / GeoAreaProvider.RadiusOfEarth) - Math.Sin(point.Latitude) * Math.Sin(coordinateToReturn.Latitude));
            return coordinateToReturn;
        }
    }
}