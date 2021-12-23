
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Client.Controllers
{
    public class TransferInController : Controller
    {
   

       
    
        public async Task<ActionResult> Index()
        {
         

            return View();
        }
        public async Task<ActionResult> Create()
        {
           
            return View();
        }

    

        // GET: RfIdScannedController/Edit/5
        public ActionResult Edit(int id)
        {
          
            return View();
        }

        // POST: RfIdScannedController/Edit/5
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

        // GET: RfIdScannedController/Delete/5
        public ActionResult Delete(int id)
        {
          
            return View();
        }

        // POST: RfIdScannedController/Delete/5
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
