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
    public class SupplierController : ControllerBase
    {
        private readonly ISuppilerService _supplierService;

        public SupplierController(ISuppilerService suppilerService)
        {
            _supplierService = suppilerService;
        }
        // GET: api/<CustmerController>
        [HttpGet]
        public async Task<IEnumerable<SupplierModel>> Get()
        {
            var supplierModel = await _supplierService.GetAllSuppliers();
            return supplierModel;
        }

        // GET api/<CustmerController>/5
        [HttpGet("{id}")]
        public async Task<SupplierModel> Get(int id)
        {
            var supplierModel = await _supplierService.GetSupplierById(id);
            return supplierModel;
        }

   
    }
}
