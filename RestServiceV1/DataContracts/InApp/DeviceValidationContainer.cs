// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = DeviceValidationContainer.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace RestServiceV1.DataContracts
{
    // Dont think I need this.
    public class DeviceValidationContainer
    {
        [XmlIgnore]
        public DateTimeOffset expiryTime;

        public string DeviceType { get; set; }
        public string UserId { get; set; }
        public int VerificationCode { get; set; }

        [XmlElement("ExpiryTime")]
        public string ExpiryTimeString // format: 2011-11-11T15:05:46.4733406+01:00
        {
            get
            {
                return this.expiryTime.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz");
            }
            set
            {
                this.expiryTime = DateTimeOffset.Parse(value);
            }
        }


        [XmlIgnore]
        public DateTimeOffset ExpiryTime
        {
            get
            {
                return this.expiryTime;
            }
            set
            {
                this.expiryTime = value;
            }
        }
    }
}