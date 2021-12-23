using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class Category
    {
        public Category()
        {
            InverseParent = new HashSet<Category>();
            ProductMasters = new HashSet<ProductMaster>();
        }

        public int Id { get; set; }
        [DisplayName("أسم عربي")]

        public string NameAr { get; set; }
        [DisplayName("أسم انجليزي")]

        public string NameEn { get; set; }
        [DisplayName("القسم الرئيسي")]

        public int? ParentId { get; set; }

        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> InverseParent { get; set; }
        public virtual ICollection<ProductMaster> ProductMasters { get; set; }
    }
}
