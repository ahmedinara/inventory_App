using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Core.Dtos
{
  public  class ItemScannedModel
    {
        public string ProductCode { get; set; }
        public double ScannedStock { get; set; }
        public string LocationCode { get; set; }
        public string TagValue { get; set; }

    }
}
