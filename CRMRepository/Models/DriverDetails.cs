using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace CRMRepository.Models
{

    [SerializableAttribute]
    [DataContract]
    public class DriverDetails
    {
        [DataMember]
        public Guid _Id { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string ContactNo { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public int ParentBranchId { get; set; }
        [DataMember]
        public string GoogleAddress { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string Pincode { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public float latitude { get; set; }
        [DataMember]
        public float longitude { get; set; }
        [DataMember]
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        [DataMember]
        public Nullable<DateTime> UpdatedAt { get; set; }
        [DataMember]
        public Nullable<int> UpdatedBy { get; set; }
        [DataMember]
        public Nullable<bool> IsActive { get; set; }
        [NotMapped]
        public string ImgStr { get; set; }

    }
}
