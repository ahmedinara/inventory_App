using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class MeasuringUnit
    {
        public MeasuringUnit()
        {
            ProductMasters = new HashSet<ProductMaster>();
        }

        public int Id { get; set; }
        [DisplayName("أسم عربي")]

        public string NameAr { get; set; }
        [DisplayName("أسم انجليزي")]

        public string NameEn { get; set; }

        public virtual ICollection<ProductMaster> ProductMasters { get; set; }
    }
}
