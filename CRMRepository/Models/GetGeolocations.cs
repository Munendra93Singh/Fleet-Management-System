using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FleetManagementRepository.Models
{
    [SerializableAttribute]
    [DataContract]
    public  class GetGeolocations
    {
        [DataMember]
        public Guid _Id { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int TruckTypeId { get; set; }
        [DataMember]
        public int DriverId { get; set; }
        [DataMember]
        public int TruckId { get; set; }
        [DataMember]
        public int TaskId { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Logitude { get; set; }
        [DataMember]
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        [DataMember]
        public Nullable<DateTime> UpdatedAt { get; set; }
        [DataMember]
        public Nullable<int> UpdatedBy { get; set; }
        [DataMember]
        public Nullable<bool> IsActive { get; set; }
     }
}

