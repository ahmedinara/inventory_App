using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfIDAicTec.Models
{
   public class TransactionOutModel
    {
     
            public string InvoiceNo { get; set; }
            public int ItemsCount { get; set; }
            public int CustmerId { get; set; }
            public DateTime TransferDate { get; set; }
            public List<TransferOutDetail> TransferOutDetails { get; set; }
       
    }
    public class TransferOutDetail
    {
        public int productId { get; set; }
        public string productCode { get; set; }
        public int qty { get; set; }
    }
}
