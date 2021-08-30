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
    public class ApiDriver
    {
        //public object Body;

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
        public string ApiUrl { get; set; }
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
