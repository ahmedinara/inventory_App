using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Core.Models
{
   public class SupplierModel
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
    }
}
