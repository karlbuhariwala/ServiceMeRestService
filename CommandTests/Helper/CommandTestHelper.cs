// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = CommandTestHelper.cs

namespace CommandTests.Helper
{
    using System;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization.Json;

    /// <summary>
    /// Command test helper class
    /// </summary>
    public static class CommandTestHelper
    {
        /// <summary>
        /// The request string
        /// </summary>
        private const string RequestString = "http://localhost:55398/ServiceMe.svc/{0}";

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="requestApi">The request API.</param>
        /// <param name="data">The data.</param>
        /// <returns>The result of the command</returns>
        /// <exception cref="System.Exception">Error</exception>
        public static V SendRequest<T, V>(string requestApi, T data)
        {
            //        ServicePointManager.Expect100Continue = true;
            //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            //        ServicePointManager
            //.ServerCertificateValidationCallback +=
            //(sender, cert, chain, sslPolicyErrors) => true;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(CommandTestHelper.RequestString, requestApi));
            request.Method = "POST";
            request.ContentType = "application/json";
            //request.ClientCertificates.Add(Program.GetCertificate("serviceme247.cloudapp.net"));

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

            bool readNow = true;
            if (readNow)
            {
                MemoryStream memoryStream = new MemoryStream();
                serializer.WriteObject(memoryStream, data);
                memoryStream.Position = 0;
                StreamReader sr = new StreamReader(memoryStream);
                string jsonText = sr.ReadToEnd();
            }

            using (Stream stream = request.GetRequestStream())
            {
                serializer.WriteObject(stream, data);
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(V));
                        return (V)deserializer.ReadObject(responseStream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the certificate from the Local Machine store, based on the given certificateSubject
        /// </summary>
        /// <param name="certificateSubject">certificate subject</param>
        /// <returns>the x509 certificate</returns>
        //private static X509Certificate GetCertificate(string certificateSubject)
        //{
        //    X509Certificate certificate = null;
        //    X509Store localMachineStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
        //    localMachineStore.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

        //    try
        //    {
        //        X509Certificate2Collection certificates = localMachineStore.Certificates.Find(
        //            X509FindType.FindBySubjectName,
        //            certificateSubject,
        //            false);

        //        certificate = (certificates.Count > 0) ? certificates[0] : null;
        //    }
        //    finally
        //    {
        //        if (localMachineStore != null)
        //        {
        //            localMachineStore.Close();
        //        }
        //    }

        //    return certificate;
        //}
    }
}
