using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using CRMRepository.Models;

namespace FleetManagementRepository.Models
{

    [SerializableAttribute]
    [DataContract]
    public class TruckDriverDetails
    {

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int TruckDetailsId { get; set; }
        [DataMember]
        public int ParentBranchId { get; set; }
        [DataMember]
        public int DriverDetailsId { get; set; }
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
        public TruckDetails TruckDetails { get; set; }
        public DriverDetails DriverDetails { get; set; }




    }
}
