using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class ProductMaster
    {
        public ProductMaster()
        {
            ProductVarients = new HashSet<ProductVarient>();
        }

        public int Id { get; set; }
        [DisplayName("كود الصنف")]
        public string Code { get; set; }

        [DisplayName("اسم الصنف عربي")]
        public string TitleAr { get; set; }

        [DisplayName("اسم الصنف انجليزي")]
        public string TitleEn { get; set; }
        
        [DisplayName("المستخدم")]
        public int CreatedBy { get; set; }

        [DisplayName("تاريخ الاشاء")]
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdateOn { get; set; }
        public int? LastUpdateBy { get; set; }

        [DisplayName("حذف")]
        public bool? IsDeleted { get; set; }

        [DisplayName("الوحده")]
        public int MeasuringUnitId { get; set; }

        [DisplayName("القسم")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User CreatedByNavigation { get; set; }
        public virtual User LastUpdateByNavigation { get; set; }
        public virtual MeasuringUnit MeasuringUnit { get; set; }
        public virtual ICollection<ProductVarient> ProductVarients { get; set; }
    }
}
