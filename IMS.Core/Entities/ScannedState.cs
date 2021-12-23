using System;
using System.Collections.Generic;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class ScannedState
    {
        public ScannedState()
        {
            ItemScanneds = new HashSet<ItemScanned>();
        }

        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public virtual ICollection<ItemScanned> ItemScanneds { get; set; }
    }
}
