// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = TestDataClass.cs

namespace RestServiceV1.DataContracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Web;

    [DataContract]
    public class TestDataClass
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}