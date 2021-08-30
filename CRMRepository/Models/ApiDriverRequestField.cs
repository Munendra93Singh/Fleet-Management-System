using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRMRepository.Models
{
    [SerializableAttribute]
    [DataContract]
    class ApiDriverRequestField
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ApiDriverId { get; set; }
        [DataMember]
        public string key { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public Nullable<bool> IsActive { get; set; }

    }
}
