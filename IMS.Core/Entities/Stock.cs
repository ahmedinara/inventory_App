using System;
using System.Collections.Generic;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class Stock
    {
        public int Id { get; set; }
        public int ProductVarientId { get; set; }
        public string VarientCode { get; set; }
        public int PhysicalStock { get; set; }
        public int ReservedStock { get; set; }
        public int OrderedStock { get; set; }
        public int AvaliableStock { get; set; }
        public int? LocationId { get; set; }

        public virtual ProductVarient ProductVarient { get; set; }
    }
}
