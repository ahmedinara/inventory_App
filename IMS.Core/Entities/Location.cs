using System;
using System.Collections.Generic;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class Location
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string LocationCode { get; set; }
    }
}
