using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IMS.Core.Entities
{
   public class DeviceRfid
    { 
        public int Id { get; set; }
        [DisplayName("Device Name ")]
        public string DeviceName { get; set; }
        [DisplayName("IP Address")]
        public string IpAddress { get; set; }
        [DisplayName("Port")]
        public string Port { get; set; }
    }
}
