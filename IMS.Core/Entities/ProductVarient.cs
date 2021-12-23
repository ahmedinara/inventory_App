using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class ProductVarient
    {
        public ProductVarient()
        {
            ItemScanneds = new HashSet<ItemScanned>();
            Stocks = new HashSet<Stock>();
            TransferInDetails = new HashSet<TransferInDetail>();
            TransferOutDetails = new HashSet<TransferOutDetail>();
        }

        public int Id { get; set; }

        [DisplayName("منتاج الرئيسي")]
        public int ProductId { get; set; }

        [DisplayName("سريال الصنف")]
        public string VarientCode { get; set; }

        [DisplayName("وصف")]
        public int CombinedAttributeId { get; set;}
        [DisplayName("كود التاج")]
        public string RfidCode { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ProductMaster Product { get; set; }
        public virtual ICollection<ItemScanned> ItemScanneds { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<TransferInDetail> TransferInDetails { get; set; }
        public virtual ICollection<TransferOutDetail> TransferOutDetails { get; set; }
    }
}
