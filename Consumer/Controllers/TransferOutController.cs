
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Client.Controllers
{
    public class TransferOutController : Controller
    {
   
      

      
        public async Task<ActionResult> Details(int id)
        {
           

            return View();
        }
        public async Task<ActionResult> Index()
        {
          

            return View();
        }
        // GET: RfIdScannedController/Create
        public async Task<ActionResult> Create()
        {
          

            return View();
        }

        // POST: RfIdScannedController/Create
      
    }
}
