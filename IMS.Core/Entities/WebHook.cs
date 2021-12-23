using System;
using System.Collections.Generic;

#nullable disable

namespace IMS.Core.Entities
{
    public partial class WebHook
    {
        public int Id { get; set; }
        public string Obj { get; set; }
        public DateTime? DateIn { get; set; }
    }
}
