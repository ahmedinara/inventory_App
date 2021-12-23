using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Core.Models
{
   public class TransferInModel
    {
        public string InvoiceNo { get; set; }        
        public int? ItemsCount { get; set; }
        public int SupplierId { get; set; }
        public DateTime TransferDate { get; set; }

        public virtual ICollection<TransferInDetailsModel> TransferInDetails { get; set; }


    }
}
