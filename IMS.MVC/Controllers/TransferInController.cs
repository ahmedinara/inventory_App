using AutoMapper;
using IMS.Core.Entities;
using IMS.Core.Models;
using IMS.Core.Service;
using IMS.Core.Shared;
using IMS.MVC.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.MVC.Controllers
{
    public class TransferInController : Controller
    {
        private readonly ITransferInService _transferInService;
        private readonly ISuppilerService _suppilerService;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public TransferInController(IMapper mapper,
            ISuppilerService suppilerService,
            ITransferInService transferInService,
            IProductService productService)
        {
            _productService = productService;
            _mapper = mapper;
            _suppilerService = suppilerService;
            _transferInService = transferInService;
        }

        public string CheckProduct(string code)
        {
            var product =  _productService.GetProductByCode(code);
            return product == null ? "0" : "1";
        }
        // GET: RfIdScannedController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            var dto = await _transferInService.GetTransferInById(id);

            return View(dto);
        }
        public async Task<ActionResult> Index()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            var transferin = await _transferInService.GetAllTransferIns();

            return View(transferin);
        }
        public async Task<ActionResult> Create()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");

            ViewData["Supplier"] = new SelectList(await _suppilerService.GetAllSuppliers(), "Id", "NameAr");

            return View();
        }

        [HttpPost]
        public async Task <string> Create([FromBody] TransferInModel transferInModel)
        {
            try
            {
                User Authenticated = HttpContext.Session.GetObject<User>("user");
                if(transferInModel==null||transferInModel.TransferInDetails.Count==0)
                    return "0";

                await _transferInService.AddTransferInModel(transferInModel, Authenticated.Id);
                return "1";
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
