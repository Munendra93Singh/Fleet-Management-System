using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FleetManagementRepository.Models
{
    [SerializableAttribute]
    [DataContract]
    public class TruckCompartment
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int TruckDetailsId { get; set; }
        [DataMember]
        public int ParentBranchId { get; set; }
        [DataMember]
        public string Fuel { get; set; }
        [DataMember]
        public decimal Capacity { get; set; }
        [DataMember]
        public decimal CurrentAmount { get; set; }
        [DataMember]
        public Nullable<int> CreatedBy { get; set; }
        [DataMember]
        public Nullable<DateTime> CreatedDate { get; set; }
        [DataMember]
        public Nullable<DateTime> UpdatedAt { get; set; }
        [DataMember]
        public Nullable<int> UpdatedBy { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
    }
}
