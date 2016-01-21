// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = PhoneVerificationProvider.cs

namespace RestServiceV1.Providers
{
    using DataContracts.InApp;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization.Json;

    /// <summary>
    /// Phone verfication provider class
    /// </summary>
    public class PhoneVerificationProvider : IPhoneVerificationProvider
    {
        /// <summary>
        /// The information bip authorization code
        /// </summary>
        private string infoBipAuthorizationCode;

        /// <summary>
        /// The send verification SMS URL
        /// </summary>
        private string sendVerificationSmsUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneVerificationProvider"/> class.
        /// </summary>
        public PhoneVerificationProvider()
        {
            this.sendVerificationSmsUrl = ConfigurationManager.AppSettings["SendVerificationSmsUrl"];
            this.infoBipAuthorizationCode = ConfigurationManager.AppSettings["InfoBipAuthorizationCode"];
        }

        /// <summary>
        /// Sends the verification SMS.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="verificationCode">The verification code.</param>
        /// <exception cref="System.Exception">Error:  + ex.Message</exception>
        void IPhoneVerificationProvider.SendVerificationSMS(string phone, string verificationCode)
        {
            InfoBipSingleTextContainer infoBipSingleTextContainer = new InfoBipSingleTextContainer();
            infoBipSingleTextContainer.From = "ServiceMe";
            infoBipSingleTextContainer.To = phone;
            infoBipSingleTextContainer.Text = string.Format("ServiceMe verification code is {0}", verificationCode);


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.sendVerificationSmsUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "Basic " + this.infoBipAuthorizationCode);

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(InfoBipSingleTextContainer));

            bool readNow = false;
            if (readNow)
            {
                MemoryStream memoryStream = new MemoryStream();
                serializer.WriteObject(memoryStream, infoBipSingleTextContainer);
                memoryStream.Position = 0;
                StreamReader sr = new StreamReader(memoryStream);
                string jsonText = sr.ReadToEnd();
            }

            using (Stream stream = request.GetRequestStream())
            {
                serializer.WriteObject(stream, infoBipSingleTextContainer);
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