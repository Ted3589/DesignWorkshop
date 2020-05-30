using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Api.Models
{
    [DataContract]
    public partial class Client
    {
        public Client()
        {
            Requests = new HashSet<Request>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [XmlIgnore]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
