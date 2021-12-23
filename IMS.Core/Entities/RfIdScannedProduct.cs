using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class RfIdScannedProduct
    {
        public RfIdScannedProduct()
        {
            ItemScanneds = new HashSet<ItemScanned>();
        }

        public int Id { get; set; }
        public int CreatedBy { get; set; }
        [DisplayName("تاريخ الانشاء")]
        public DateTime CreatedOn { get; set; }
        [DisplayName("عدد لاصناف")]

        public int ItemsCount { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual ICollection<ItemScanned> ItemScanneds { get; set; }
    }
}
