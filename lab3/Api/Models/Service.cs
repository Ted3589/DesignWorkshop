using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Api.Models
{
    [DataContract]
    public partial class Service
    {
        public Service()
        {
            Requests = new HashSet<Request>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string Description { get; set; }

        [XmlIgnore]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
