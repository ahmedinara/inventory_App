using Core.Models;
using IMS.Client.Shared;
using IMS.Core.Entities;
using IMS.Core.Service;
using IMS.Core.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IMS.Client.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UserController(IUserService userService , IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        // GET: UserController
        public async Task<ActionResult> Index()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            return View(await _userService.GetUsers());
        }
        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {

            if (!ModelState.IsValid) return View(loginModel);
            User authResult = await _authService.ValidateUserMVCAsync(loginModel.Email, loginModel.Password);
        
            if (authResult ==null)
            {
                ModelState.AddModelError("Password", "كلمة السر خاطئة");
                return View(loginModel);
            }
            // Create Session 
            HttpContext.Session.SetObject("user", authResult);
            ViewData["username"] = authResult.FristName+authResult.LastName;
            TempData["LoginSuccessfully"] = "Success";
            TempData["LoginSuccessfullyMessage"] = "تم تسجيل الدخول بنجاح";
            
            return RedirectToAction("Index", "Home");
        }
        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            return View(await _userService.GetUserById(id));
        }

        // GET: UserController/Create
        public async Task<ActionResult> Create()
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                User isAuthenticated = HttpContext.Session.GetObject<User>("user");
                if (isAuthenticated == null) return RedirectToAction("Login", "User");
                await _userService.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            User isAuthenticated = HttpContext.Session.GetObject<User>("user");
            if (isAuthenticated == null) return RedirectToAction("Login", "User");
            return View(await _userService.GetUserById(id));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                User isAuthenticated = HttpContext.Session.GetObject<User>("user");
                if (isAuthenticated == null) return RedirectToAction("Login", "User");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
