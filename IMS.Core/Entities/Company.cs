using System;
using System.Collections.Generic;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class Company
    {
        public Company()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string LogoUrl { get; set; }
        public string Address { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
