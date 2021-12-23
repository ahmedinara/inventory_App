
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IMS.Client.Controllers

{

    public partial class RfidViewController : Controller
    {

       
        public ActionResult Index()
        {
        
            return View();
        }

        public async Task<ActionResult> DeviceConnect()
        {
          
            return View();
        }
      
        //[HttpPost]
        //public async Task<ActionResult<string>> DeviceConnect(DeviceRfid deviceRfid)
        //{
        //    User isAuthenticated = HttpContext.Session.GetObject<User>("user");
        //    if (isAuthenticated == null) return RedirectToAction("Login", "User");
        //    //IAsynchronousMessage asynchronousMessage =null;
        //    //String tcp = deviceRfid.IpAddress+":"+ deviceRfid.Port;
        //    //if (RFIDReaderAPI.RFIDReader.CreateTcpConn(tcp, asynchronousMessage))
        //    //{
        //    //    var rt = RFIDReader._ReaderConfig.GetDataOutPutFormat(tcp);
        //    //    // Switch|Data format| Data content| STX| ETX
        //    //}
        //    return "1";
        //}
        // GET: RfidViewController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: RfidViewController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
       
            return View();
        }

       //[HttpPost]
       // public async Task<ActionResult> Create([FromBody]  IEnumerable<ItemScannedModel> jsontext)
       // {
       //     try
       //     {
       //         User isAuthenticated = HttpContext.Session.GetObject<User>("user");
       //         if (isAuthenticated == null) return RedirectToAction("Login", "User");
       //         //var respond = JsonConvert.DeserializeObject<List<ItemScannedModel>>(jsontext); 
              
       //         await _rfIdScannedProductService.AddScannedItems(jsontext.ToList(), isAuthenticated.Id);
       //         return Ok("1");
       //     }
       //     catch
       //     {
       //         return Ok("0");
       //     }
       // }

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

        
    }
}
