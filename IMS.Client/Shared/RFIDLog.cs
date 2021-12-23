using RFIDReaderAPI.Interface;
using RFIDReaderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Client.Shared
{
    public class RFIDLog : IAsynchronousMessage
    {
        public GPI_Model gpi_model;
        public Tag_Model tag;
        public bool IsOutPutTagsOver=false;
        public string connIDPortClosing;
        public string connIDPortConnecting;
        public string  msg;
        public void GPIControlMsg(GPI_Model gpi_model)
        {
           this.gpi_model=gpi_model;
        }

        public void OutPutTags(Tag_Model tag)
        {
            this.tag = tag;
        }

        public void OutPutTagsOver()
        {
            IsOutPutTagsOver = true;
        }

        public void PortClosing(string connID)
        {
            this.connIDPortClosing = connID;
        }

        public void PortConnecting(string connID)
        {
            this.connIDPortConnecting = connID;
        }

        public void WriteDebugMsg(string msg)
        {
            this.msg = msg;
        }

        public void WriteLog(string msg)
        {
            this.msg = msg;
        }
    }
}
