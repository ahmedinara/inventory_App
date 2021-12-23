using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Core.Models
{
   public class DeviceConnectModel
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
    }
}
