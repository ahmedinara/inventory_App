using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IMS.Core.Models
{
   public class ProductVarientWithParentModel
    {
        public int Id { get; set; }
        [DisplayName("أسم الصنف عربي")]

        public string TitleAr { get; set; }
        [DisplayName("أسم الصنف انجليزي")]

        public string TitleEn { get; set; }


        [DisplayName("سريال الصنف")]
        public string VarientCode { get; set; }

        [DisplayName("وصف")]
        public int CombinedAttributeId { get; set; }
        [DisplayName("كود التاج")]
        public string RfidCode { get; set; }
        [DisplayName("تاريخ الانشاء")]

        public DateTime? CreatedOn { get; set; }
        [DisplayName("الكميه")]

        public float StockQty { get; set; }
    }
}
