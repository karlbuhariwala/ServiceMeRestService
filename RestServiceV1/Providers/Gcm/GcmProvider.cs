// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = IGcmProvider.cs

namespace RestServiceV1.Providers
{
    using DataContracts;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization.Json;

    /// <summary>
    /// Gcm Provider
    /// </summary>
    public class GcmProvider : IGcmProvider
    {
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="notificationId">The notification identifier.</param>
        /// <param name="message">The message.</param>
        void IGcmProvider.SendMessage(GcmContainer message)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["GcmEndpoint"]);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", ConfigurationManager.AppSettings["GoogleEndpointAuthorizationKey"]);

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GcmContainer));

            bool readNow = false;
            if (readNow)
            {
                MemoryStream memoryStream = new MemoryStream();
                serializer.WriteObject(memoryStream, message);
                memoryStream.Position = 0;
                StreamReader sr = new StreamReader(memoryStream);
                string jsonText = sr.ReadToEnd();
            }

            using (Stream stream = request.GetRequestStream())
            {
                serializer.WriteObject(stream, message);
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (readNow)
                        {
                            StreamReader sr = new StreamReader(responseStream);
                            string jsonText = sr.ReadToEnd();
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