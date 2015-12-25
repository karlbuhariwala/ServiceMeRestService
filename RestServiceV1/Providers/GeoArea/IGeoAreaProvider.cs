// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = IGeoAreaProvider.cs

namespace RestServiceV1.Providers
{
    using DataContracts.InApp;

    /// <summary>
    /// IGeoAreaProvider interface
    /// </summary>
    /// <seealso cref="RestServiceV1.Providers.IProvider" />
    interface IGeoAreaProvider : IProvider
    {
        /// <summary>
        /// Gets the boundary.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="distanceInKm">The distance in km.</param>
        /// <param name="topLeft">The top left.</param>
        /// <param name="bottomRight">The bottom right.</param>
        void GetBoundary(Coordinates point, double distanceInKm, out Coordinates topLeft, out Coordinates bottomRight);
    }
}
