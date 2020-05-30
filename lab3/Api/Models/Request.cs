using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Api.Models
{
    [DataContract]
    public partial class Request
    {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int ServiceId { get; set; }

        [DataMember]
        public virtual Client Client { get; set; }

        [DataMember]
        public virtual Service Service { get; set; }
    }
}
