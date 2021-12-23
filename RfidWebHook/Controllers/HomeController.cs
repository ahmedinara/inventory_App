using IMS.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RfidWebHook.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RfidWebHook.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IWebHookRepository _webHookRepository;

        public HomeController(ILogger<HomeController> logger, IWebHookRepository webHookRepository)
        {
            _logger = logger;
            _webHookRepository = webHookRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> RfidRead([FromBody] object obj)
        {
            var result = obj;
            try
            {
                var entity = await _webHookRepository.AddWebHook(new IMS.Core.Entities.WebHook { DateIn = DateTime.Now, Obj = obj.ToString() });
            }
            catch (Exception ex)
            {
                var entity = await _webHookRepository.AddWebHook(new IMS.Core.Entities.WebHook { DateIn = DateTime.Now, Obj = ex.ToString() });
            }
            return Ok(obj);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
