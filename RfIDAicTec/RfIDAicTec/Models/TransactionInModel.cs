using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfIDAicTec.Models
{
    public class TransactionInModel
    {
            public string InvoiceNo { get; set; }
            public int ItemsCount { get; set; }
            public int SupllierId { get; set; }
            public DateTime TransferDate { get; set; }
            public List<TransferInDetail> TransferInDetails { get; set; }
    }
    public class TransferInDetail
    {
        public int productId { get; set; }
        public string productCode { get; set; }
        public int qty { get; set; }
    }
}
