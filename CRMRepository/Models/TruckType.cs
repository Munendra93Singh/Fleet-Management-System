using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FleetManagementRepository.Models
{
    [SerializableAttribute]
    [DataContract]
    public class TruckType
    {

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ParentBranchId { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public Nullable<bool> IsActive { get; set; }

    }
}
