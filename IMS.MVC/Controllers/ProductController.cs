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
    public class ProductController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly ICategoryService _categoryService;
        private readonly IMeasuringUnitService _measuringUnitService;
        private readonly IScannedProductService _rfIdScannedProductService;

        private readonly IProductService _productService;

        public ProductController(IProductService productService,
            ILocationService locationService,
            ICategoryService categoryService,
            IMeasuringUnitService measuringUnitService,
            IScannedProductService rfIdScannedProductService)
        {
            _productService = productService;
            _locationService = locationService;
            _categoryService = categoryService;
            _measuringUnitService = measuringUnitService;
            _rfIdScannedProductService = rfIdScannedProductService;
        }
        // GET: RfIdScannedController
        public async Task<ActionResult> Counting()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            var dto = await _rfIdScannedProductService.GetRfIdScannedProducts();
            return View(dto);
        }

        // GET: RfIdScannedController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            var dto = await _rfIdScannedProductService.GetRfIdScannedProductById(id);

            return View(dto);
        }
        public async Task<ActionResult> Index()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            var product = await _productService.GetProducts();

            return View(product);
        }
        // GET: RfIdScannedController/Create
        public async Task<ActionResult> Create()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            ViewData["Category"] = new SelectList(await _categoryService.GetAllCategories(), "Id", "NameAr");
            //ViewData["Location"] = new SelectList(await _locationService.GetAllLocations(), "Id", "LocationCode");
            ViewData["MeasuringUnit"] = new SelectList(await _measuringUnitService.GetAllMeasuringUnits(), "Id", "NameAr");

            return View();
        }

        // POST: RfIdScannedController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(ProductMasterModel productMasterModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User Authenticated = HttpContext.Session.GetObject<User>("user");

                    await _productService.AddProduct(productMasterModel, Authenticated.Id);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
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
