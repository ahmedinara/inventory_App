using System;
using System.Collections.Generic;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class ItemScanned
    {
        public int Id { get; set; }
        public int? ProductVarientCode { get; set; }
        public int LocationId { get; set; }
        public double ScannedStock { get; set; }
        public double PhysicalStock { get; set; }
        public string LocationCode { get; set; }
        public string VariantCode { get; set; }
        public int StatesId { get; set; }
        public int ScannedId { get; set; }
        public string TagValue { get; set; }

        public virtual ProductVarient ProductVarientCodeNavigation { get; set; }
        public virtual RfIdScannedProduct Scanned { get; set; }
        public virtual ScannedState States { get; set; }
    }
}
