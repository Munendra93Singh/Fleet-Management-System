using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace FleetManagementRepository.Models
{
    [SerializableAttribute]
    [DataContract]
    public class UserOtp
    {
        [DataMember]
        public Guid _Id { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string OtpCode { get; set; }
        [DataMember]
        public string Varification { get; set; }
        [DataMember]
        public string Role { get; set; }
        [DataMember]
        public string Password { get; set; }
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
