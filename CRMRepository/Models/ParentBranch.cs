using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FleetManagementRepository.Models
{
    [SerializableAttribute]
    [DataContract]
    public class ParentBranch
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Pin { get; set; }
        [DataMember]
        public Nullable<int> CreatedBy { get; set; }
        [DataMember]
        public Nullable<DateTime> CreatedDate { get; set; }
        [DataMember]
        public Nullable<DateTime> UpdatedAt { get; set; }
        [DataMember]
        public Nullable<int> UpdatedBy { get; set; }
        [DataMember]
        public Nullable<bool> IsActive { get; set; }

    }
}
