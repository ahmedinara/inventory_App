using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfIDAicTec.Models
{
    public class TransactionInDeskTopDto
    {
        public string InvoiceNo { get; set; }
        public int? ItemsCount { get; set; }
        public int SupplierId { get; set; }
        public DateTime TransferDate { get; set; }
        public int ProductId { get; set; }

        public string Code { get; set; }

        public string TitleAr { get; set; }

        public string TitleEn { get; set; }

        public int CategoryId { get; set; }
        public virtual ICollection<TransferInDetail> TransferInDetails { get; set; }
    }
}
