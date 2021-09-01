using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace FleetManagementRepository.Models
{
    [SerializableAttribute]
    [DataContract]
    public class TruckDetails
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ParentBranchId { get; set; }
        [DataMember]
        public int TruckTypeId { get; set; }
        [DataMember]
        public string EldDeviceNo { get; set; }
        [DataMember]
        public string TruckNo { get; set; }
        [DataMember]
        public string GpsPosition { get; set; }
        [DataMember]
        public bool EldMonitored { get; set; }
        [DataMember]
        public string TruckPlate { get; set; }
        [DataMember]
        public string CurrentOdoMeter { get; set; }
        [DataMember]
        public bool AutoRFID { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public string VinNumber { get; set; }
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
        public IEnumerable<TruckCompartment> TruckCompartment { get; set; }
        [NotMapped]
        public string ImgStr { get; set; }

    }
}
