using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Core.Models
{
   public class TransferInDetailsModel
    {
        public int Qty { get; set; }
        public int ProductVarientId { get; set; }
        public string TagValue { get; set; }
        public string VarientCode { get; set; }
    }
}
