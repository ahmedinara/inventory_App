using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Core.Models
{
   public class TransferOutModel
    {
        public string InvoiceNo { get; set; }
        public int ItemsCount { get; set; }
        public int CustmerId { get; set; }
        public DateTime TransferDate { get; set; }

        public virtual ICollection<TransferOutDetialModel> TransferOutDetails { get; set; }

    }
}
