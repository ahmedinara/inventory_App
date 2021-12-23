using AutoMapper;
using IMS.Core.Entities;
using IMS.Core.Models;
using IMS.Core.Service;
using IMS.Core.Shared;
using IMS.Client.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Client.Controllers
{
    public class TransferOutController : Controller
    {
        private readonly ITransferOutService _transferOutService;
        private readonly ICustmerService _custmerService;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public TransferOutController(IMapper mapper,
            ICustmerService custmerService,
            ITransferOutService transferOutService,
            IProductService productService)
        {
            _productService = productService;
            _mapper = mapper;
            _custmerService = custmerService;
            _transferOutService = transferOutService;
        }

        public string CheckProduct(string code)
        {
            var product =  _transferOutService.IsAcceptProduct(code);
            return product == false ? "0" : "1";
        }
        // GET: RfIdScannedController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            var dto = await _transferOutService.GetTransferOutById(id);

            return View(dto);
        }
        public async Task<ActionResult> Index()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            var transferin = await _transferOutService.GetAllTransferOuts();

            return View(transferin);
        }
        // GET: RfIdScannedController/Create
        public async Task<ActionResult> Create()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");

            ViewData["Supplier"] = new SelectList(await _custmerService.GetAllCustmers(), "Id", "NameAr");

            return View();
        }

        // POST: RfIdScannedController/Create
        [HttpPost]
        public async Task <object> Create([FromBody] TransferOutModel transferOutModel)
        {
            try
            {
                User Authenticated = HttpContext.Session.GetObject<User>("user");
                if(transferOutModel==null||transferOutModel.TransferOutDetails.Count==0)
                    return "0";

              var result =  await _transferOutService.AddTransferOutModel(transferOutModel, Authenticated.Id);
                if (result.IsSucceeded == false)
                    return JsonConvert.SerializeObject(new { result = result.ErrorMessage }, Formatting.None,
                             new JsonSerializerSettings()
                             {
                                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                             });
                else
                    return new { result = "1" };
            }
            catch
            {
                return "0";
            }
        }

        // GET: RfIdScannedController/Edit/5
        public ActionResult Edit(int id)
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
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
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
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
