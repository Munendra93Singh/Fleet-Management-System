using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CRMRepository.Models
{
    [SerializableAttribute]
    [DataContract]
    class ApiTypeDriver
    {
        [DataMember]
        public Guid _Id { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Method { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public Nullable<bool> IsActive { get; set; }

    }
}
