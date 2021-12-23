using IMS.Client.Shared;
using IMS.Core.Dtos;
using IMS.Core.Entities;
using IMS.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RFIDReaderAPI;
using RFIDReaderAPI.Interface;
using RFIDReaderAPI.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IMS.Client.Controllers

{

    public partial class RfidViewController : Controller, IAsynchronousMessage
    {
        private readonly IScannedProductService _rfIdScannedProductService;

        public RfidViewController(IScannedProductService rfIdScannedProductService)
        {
            _rfIdScannedProductService = rfIdScannedProductService;
        }
        // GET: RfidViewController
        public ActionResult Index()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            return View();
        }

        public async Task<ActionResult> DeviceConnect()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            return View();
        }
        //private void InitCom(DeviceRfid deviceRfid)
        //{
        //    bool isConnect = false;

        //    var connaction = deviceRfid.IpAddress + ":" + deviceRfid.Port;
        //     if (deviceRfid != null)
        //    {
        //        isConnect = RFIDReader.CreateTcpConn(connaction, _log);
        //      //  Helper.MyXmlHelper.UpdateInnerText(XMLFIENAME, "Root/AddConnect", "TcpConnect", tb_ConnParam.Text.Trim());
        //    }


        //    if (isConnect)
        //    {
        //        if (!RFIDReader.CheckConnect(connaction))
        //        {
        //            if (RFIDReader.DIC_CONNECT.ContainsKey(connaction))
        //            {
        //                RFIDReader.CloseConn(connaction);
        //            }

        //            return;
        //        }

        //        //    if (!String.IsNullOrEmpty(contextForm.ConnID))
        //        //    {
        //        //        RFIDReaderAPI.RFIDReader.DIC_CONNECT[contextForm.ConnID].log = null;
        //        //    }

        //        //contextForm.ConnID = tb_ConnParam.Text.Trim();
        //    }
        //    else
        //    {
        //    }
        //}
        [HttpPost]
        public ActionResult<string> DeviceConnect([FromBody] DeviceRfid deviceRfid)
        {

            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            try
            {
                IAsynchronousMessage asynchronousMessage = new RFIDLog();
                String tcp = deviceRfid.IpAddress;
                var isConnected = RFIDReaderAPI.RFIDReader.CreateTcpConn(tcp.Trim(), asynchronousMessage);
                if (isConnected)
                {
                    var rt = RFIDReader._ReaderConfig.GetDataOutPutFormat(tcp);
                    // Switch|Data format| Data content| STX| ETX
                    return JsonConvert.SerializeObject("success : " + rt, Formatting.None,
                         new JsonSerializerSettings()
                         {
                             ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                         }); 
                }
                else
                    return "0";

            }
            catch (Exception ex)
            {
                var x = ex.ToString();
                return JsonConvert.SerializeObject("Error : "+x, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }); ;
            }

        }
        // GET: RfidViewController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: RfidViewController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            return View();
        }

       [HttpPost]
        public async Task<ActionResult> Create([FromBody]  IEnumerable<ItemScannedModel> jsontext)
        {
            try
            {
                User isAuthenticated = HttpContext.Session.GetObject<User>("user");
                if (isAuthenticated == null) return RedirectToAction("Login", "User");
                //var respond = JsonConvert.DeserializeObject<List<ItemScannedModel>>(jsontext); 
              
                await _rfIdScannedProductService.AddScannedItems(jsontext.ToList(), isAuthenticated.Id);
                return Ok("1");
            }
            catch
            {
                return Ok("0");
            }
        }

        // GET: RfidViewController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RfidViewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RfidViewController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RfidViewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public void WriteDebugMsg(string msg)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(string msg)
        {
            throw new NotImplementedException();
        }

        public void PortConnecting(string connID)
        {
            throw new NotImplementedException();
        }

        public void PortClosing(string connID)
        {
            throw new NotImplementedException();
        }

        public void OutPutTags(Tag_Model tag)
        {
            throw new NotImplementedException();
        }

        public void OutPutTagsOver()
        {
            throw new NotImplementedException();
        }

        public void GPIControlMsg(GPI_Model gpi_model)
        {
            throw new NotImplementedException();
        }
    }
}
