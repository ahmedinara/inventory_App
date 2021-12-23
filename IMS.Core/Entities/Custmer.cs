﻿using System;
using System.Collections.Generic;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class Custmer
    {
        public Custmer()
        {
            TransferOuts = new HashSet<TransferOut>();
        }

        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<TransferOut> TransferOuts { get; set; }
    }
}
