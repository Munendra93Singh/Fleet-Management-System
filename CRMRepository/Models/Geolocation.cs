using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FleetManagementRepository.Models
{

    [SerializableAttribute]
    [DataContract]
    public class Geolocation
    {
        [DataMember]
        public Guid _Id { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int TruckTypeId { get; set; }
        [DataMember]
        public Double DriverId { get; set; }
        [DataMember]
        public Double TruckId { get; set; }
        [DataMember]
        public Double TaskId { get; set; }
        [DataMember]
        public string TruckNo { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitute { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
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

    }
}