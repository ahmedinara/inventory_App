using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.Core.Models
{
   public class ProductVarientModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("منتاج الرئيسي")]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("سريال الصنف")]
        public string VarientCode { get; set; }

        [DisplayName("وصف")]
        public int CombinedAttributeId { get; set; }

        [DisplayName("(RFID)كود التاج")]
        [Required]
        public string RfidCode { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
