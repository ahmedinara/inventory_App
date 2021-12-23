using IMS.Core;
using IMS.Core.Dtos;
using IMS.Core.Entities;
using IMS.Core.Models;
using IMS.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IMS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IScannedProductService _rfIdScannedProductService;
        private readonly ITransferInService _transferInService;
        private readonly ITransferOutService _transferOutService;
        private readonly IProductService _productService;

        public ProductController(IScannedProductService rfIdScannedProductService,
            ITransferInService transferInService,
            ITransferOutService transferOutService,IProductService productService)
        {
            _rfIdScannedProductService = rfIdScannedProductService;
            _transferInService = transferInService;
            _transferOutService = transferOutService;
            _productService = productService;
        }

        #region get
        [HttpGet("check")]
        public string CheckProduct([FromQuery] string code)
        {
            var product = _productService.GetProductByCode(code);
            return product == null ? "0" : "1";
        }

        [HttpGet]
        public async Task<IEnumerable<ProductMasterModel>> GetProduct()
        {
            var product =await _productService.GetProductModels();
            return product;
        }
        #endregion

        #region Post

        [HttpPost("scan")]
        public async Task<ActionResult<ScannedProductsModel>> PostfIdScannedProductDtos (List<ItemScannedModel> itemScannedModels)
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            string currentUserid = identity.FindFirst("Id").Value;
            ResponseResult rfIdScannedProductMiodel = await _rfIdScannedProductService.AddScannedItems(itemScannedModels,int.Parse(currentUserid));
            return Ok(rfIdScannedProductMiodel);
        }

        [HttpPost("release")]
        public async Task<ActionResult<TransferOutModel>> PostReleaseProducts(TransferOutModel transferOutModel)
        {
            
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            string currentUserid = identity.FindFirst("Id").Value;
            var result = await _transferOutService.AddTransferOutModel(transferOutModel, int.Parse(currentUserid));
           
            return Ok(result);
        }

        [HttpPost("transferIn")]
        public async Task<ActionResult<ScannedProductsModel>> PostTransferInProducts(TransferInModel transferInModel)
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            string currentUserid = identity.FindFirst("Id").Value;
            var result = await _transferInService.AddTransferInModel(transferInModel, int.Parse(currentUserid));
            return Ok(result);

        }

        [HttpPost("transferInDesktop")]
        public async Task<ActionResult<ScannedProductsModel>> PostTransferInDesktopProducts(TransactionInDeskTopDto transferInModel)
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            string currentUserid = identity.FindFirst("Id").Value;
            var result = await _transferInService.AddTransactionInDeskTop(transferInModel, int.Parse(currentUserid));
            return Ok(result);

        }

        #endregion
    }
}
