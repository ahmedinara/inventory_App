using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class TransferIn
    {
        public TransferIn()
        {
            TransferInDetails = new HashSet<TransferInDetail>();
        }

        public int Id { get; set; }
        [DisplayName("رقم الفاتوره")]
        public string InvoiceNo { get; set; }
        [DisplayName("تاريخ لانشاء")]

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int ItemsCount { get; set; }
        public int SupplierId { get; set; }
        public DateTime? TransferDate { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User DeletedByNavigation { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User UpdateByNavigation { get; set; }
        public virtual ICollection<TransferInDetail> TransferInDetails { get; set; }
    }
}
