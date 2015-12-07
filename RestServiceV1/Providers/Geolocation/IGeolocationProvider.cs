// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = IGeolocationProvider.cs

namespace RestServiceV1.Providers.GeoLocation
{
    using DataContracts.InApp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface IGeolocationProvider : IProvider
    {
        Coordinates GetCoordinates(AddressContainer address);
    }
}
