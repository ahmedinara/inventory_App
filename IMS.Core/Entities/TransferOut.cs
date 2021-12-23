using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class TransferOut
    {
        public TransferOut()
        {
            TransferOutDetails = new HashSet<TransferOutDetail>();
        }

        public int Id { get; set; }
        [DisplayName("رقم الفاتوره")]

        public string InvoiceNo { get; set; }
        [DisplayName("تاريخ الانشاء")]

        public int CreatedBy { get; set; }
        [DisplayName("المستخدم")]

        public DateTime CreatedOn { get; set; }
        [DisplayName("تعديل بوستط")]

        public int? UpdateBy { get; set; }
        [DisplayName("تاريخ التعديل")]

        public DateTime? UpdatedOn { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        [DisplayName("عدد الاصناف")]

        public int ItemsCount { get; set; }
        [DisplayName("عميل")]

        public int CustmerId { get; set; }
        public DateTime? TransferDate { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        [DisplayName("عميل")]
        public virtual Custmer Custmer { get; set; }
        public virtual User DeletedByNavigation { get; set; }
        public virtual User UpdateByNavigation { get; set; }
        public virtual ICollection<TransferOutDetail> TransferOutDetails { get; set; }
    }
}
