using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IMS.Core.Models
{
   public class ProductMasterModel
    {
        public int Id { get; set; }
        [DisplayName("كود الصنف")]

        public string Code { get; set; }
        [DisplayName("أسم الصنف عربي")]
        [Required]
        public string TitleAr { get; set; }
        [DisplayName("أسم الصنف انجليزي")]
        [Required]

        public string TitleEn { get; set; }
        [DisplayName("المستخدم الانشاء")]

        public int CreatedBy { get; set; }
        [DisplayName("تاريخ الانشاء")]

        public DateTime CreatedOn { get; set; }
        [DisplayName("المستخدم التعديل")]

        public DateTime? LastUpdateOn { get; set; }
        [DisplayName("تاريخ التعديل")]

        public int? LastUpdateBy { get; set; }
        [DisplayName("محذوف")]

        public bool? IsDeleted { get; set; }
        //وحدة القياس
        [DisplayName("وحدة")]

        public int MeasuringUnitId { get; set; }
        [DisplayName("القسم")]

        public int CategoryId { get; set; }
    }
}
