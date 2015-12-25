// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = IGeolocationProvider.cs

namespace RestServiceV1.Providers
{
    using DataContracts;
    using DataContracts.InApp;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Web.Script.Serialization;

    /// <summary>
    /// Geolocation Provider
    /// </summary>
    public class GeolocationProvider : IGeolocationProvider
    {
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>Coordinates of address</returns>
        /// <exception cref="System.Exception">Error:  + ex.Message</exception>
        Coordinates IGeolocationProvider.GetCoordinates(AddressContainer address)
        {
            string addressString = string.Empty;
            if(!string.IsNullOrEmpty(address.AddressLine1))
            {
                addressString += address.AddressLine1.Replace(" ", "+") + ",+";
            }

            if (!string.IsNullOrEmpty(address.AddressLine2))
            {
                addressString += address.AddressLine2.Replace(" ", "+") + ",+";
            }

            addressString += address.City.Replace(" ", "+") + ",+";
            addressString += address.Country.Replace(" ", "+");
            string key = ConfigurationManager.AppSettings["GoogleEndpointAuthorizationKey"];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(ConfigurationManager.AppSettings["GeolocationEndpoint"], addressString, "&", key));
            request.Method = "GET";
            request.ContentType = "application/json";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GoogleApiGeocodeContainer));
                        GoogleApiGeocodeContainer result = (GoogleApiGeocodeContainer) serializer.ReadObject(responseStream);

                        if (result.Status == "OK")
                        {
                            Coordinates coordinates = new Coordinates();
                            coordinates.Latitude = result.Results[0].Geometry.Location.Latitude;
                            coordinates.Longitude = result.Results[0].Geometry.Location.Longitude;
                            return coordinates;
                        }
                        else
                        {
                            return new Coordinates();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}