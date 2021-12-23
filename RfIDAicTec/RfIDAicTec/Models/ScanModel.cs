using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfIDAicTec.Models
{
    public class ScanModel
    {
        public string RfidCode { get; set; }
        public string ProductCode { get; set; }
        public int ScannedStock { get; set; }
        public string LocationCode { get; set; }
    }
}
