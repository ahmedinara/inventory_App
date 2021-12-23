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
    public class ProductVareintController : Controller
    {
        private readonly IProductService _productService;

        private readonly IProductVareintService _productVareintService;

        public ProductVareintController(IProductVareintService productVareintService,
            IProductService productService)
        {
            _productVareintService = productVareintService;
            _productService = productService;
        }
     

        // GET: RfIdScannedController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            ProductVarientWithParentModel dto = await _productVareintService.GetProductById(id);
            return View(dto);
        }
        public async Task<ActionResult> Index()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            IEnumerable<ProductVarientWithParentModel> product = await _productVareintService.GetProducts();

            return View(product);
        }
        // GET: RfIdScannedController/Create
        public async Task<ActionResult> Create()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            ViewData["Product"] = new SelectList(await _productService.GetProductModels(), "Id", "TitleAr");
            return View();
        }

        // POST: RfIdScannedController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(ProductVarientModel productVarientModel)
        {
            try
            {
                ViewData["Product"] = new SelectList(await _productService.GetProductModels(), "Id", "TitleAr");

                if (ModelState.IsValid)
                {
                    User isAuthenticated = HttpContext.Session.GetObject<User>("user");
                    if (isAuthenticated == null) return RedirectToAction("Login", "User");
                  var entity=  await _productVareintService.AddProduct(productVarientModel);
                    if (entity == null)
                    {
                        ModelState.AddModelError("Error", "رقم تسلسلي أو تاج مكررة ");
                        return View();
                    }
                     
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
