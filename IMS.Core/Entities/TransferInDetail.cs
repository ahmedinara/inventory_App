using System;
using System.Collections.Generic;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class TransferInDetail
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public int TransferInId { get; set; }
        public int ProductVarientId { get; set; }
        public string TagValue { get; set; }
        public string VarientCode { get; set; }

        public virtual ProductVarient ProductVarient { get; set; }
        public virtual TransferIn TransferIn { get; set; }
    }
}
