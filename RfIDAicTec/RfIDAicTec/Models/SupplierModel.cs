using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfIDAicTec.Models
{
    public class SupplierModel
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public object UpdatedBy { get; set; }
        public object UpdatedOn { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
    }
}
