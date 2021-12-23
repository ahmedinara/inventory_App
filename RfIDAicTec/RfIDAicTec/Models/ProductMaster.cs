using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfIDAicTec.Models
{
    public class ProductMaster
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdateOn { get; set; }
        public int? LastUpdateBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int MeasuringUnitId { get; set; }
        public int CategoryId { get; set; }
    }
}
