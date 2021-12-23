using IMS.Core.Entities;
using IMS.Core.Models;
using IMS.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustmerController : ControllerBase
    {
        private readonly ICustmerService _custmerService;

        public CustmerController(ICustmerService custmerService)
        {
            _custmerService = custmerService;
        }
        // GET: api/<CustmerController>
        [HttpGet]
        public async Task<IEnumerable<CustmerModel>> Get()
        {
            var custmerModels = await _custmerService.GetAllCustmers();
            return custmerModels;
        }

        // GET api/<CustmerController>/5
        [HttpGet("{id}")]
        public async Task<CustmerModel> Get(int id)
        {
            var custmerModel = await _custmerService.GetCustmerById(id);
            return custmerModel;
        }

   
    }
}
