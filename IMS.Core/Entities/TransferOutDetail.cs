using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class TransferOutDetail
    {
        public int Id { get; set; }
        [DisplayName("الكميه")]

        public int Qty { get; set; }
        public int TransferOutId { get; set; }
        public int ProductVarientId { get; set; }
        [DisplayName("كود التاج")]

        public string TagValue { get; set; }
        [DisplayName("كود الصنف")]
        public string VarientCode { get; set; }
        [DisplayName("الصنف")]

        public virtual ProductVarient ProductVarient { get; set; }
        public virtual TransferOut TransferOut { get; set; }
    }
}
