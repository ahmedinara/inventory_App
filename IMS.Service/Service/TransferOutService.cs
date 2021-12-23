using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Core.Dtos;
using IMS.Core.Entities;
using IMS.Core.Repository;
using IMS.Core.Service;
using System.Linq;
using System.IO;
using IMS.Core.Models;
using IMS.Core;

namespace IMS.Service.Services
{
    public class TransferOutService : ITransferOutService
    {
        private readonly ITransferOutRepository _transferOutRepository;
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStockRepository _stockRepository;

        public TransferOutService(ITransferOutRepository transferOutRepository,
                          IMapper mapper, ISupplierRepository supplierRepository,IProductRepository productRepository,
                          IStockRepository stockRepository)
        {
            _transferOutRepository = transferOutRepository;
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
            _stockRepository = stockRepository;
        }

        #region Add
        public async Task<ResponseResult> AddTransferOutModel(TransferOutModel transferOutModel, int userId)
        {
            try
            {
                transferOutModel.ItemsCount = transferOutModel.TransferOutDetails.Count();
                var transferOut = _mapper.Map<TransferOut>(transferOutModel);
                bool IsValidProduct = true;

                transferOut.TransferOutDetails.ToList().ForEach(td => {
                    if (!string.IsNullOrEmpty(td.TagValue))
                    {
                        ProductVarient productVarient = getproductByRfid(td.TagValue);
                        if (productVarient != null)
                        {
                            td.ProductVarientId = productVarient.Id;
                            td.VarientCode = productVarient.VarientCode;
                        }
                        else { IsValidProduct = false; }
                    }
                    if (td.ProductVarientId == 0 && !string.IsNullOrEmpty(td.VarientCode))
                    {
                        ProductVarient productVarient = getproductByCode(td.VarientCode);
                        if (productVarient != null)
                        {
                            td.ProductVarientId = productVarient.Id;
                            td.VarientCode = productVarient.VarientCode;
                        }
                        else { IsValidProduct = false; }
                    }
                });
                if (!IsValidProduct)
                    return new ResponseResult { IsSucceeded = false, ApiStatusCode = 400, ErrorMessage = "Invalid Product" };

                transferOut.CreatedBy = userId;
                transferOut.CreatedOn = DateTime.Now;


                var result = AvalabliteProducts(transferOut.TransferOutDetails.ToList());
                if (result != "")
                    return new ResponseResult { IsSucceeded=false,ApiStatusCode=400 ,ErrorMessage=result};
                var entity = await _transferOutRepository.AddTransferOut(transferOut);
                foreach (TransferOutDetail transferOutDetail in entity.TransferOutDetails)
                {
                    var stock = await _stockRepository.GetStockByProductIdAsync(transferOutDetail.ProductVarientId);
                  
                    if (stock != null)
                    {
                        if (stock.PhysicalStock >= transferOutDetail.Qty)
                        {
                            stock.PhysicalStock -= transferOutDetail.Qty;
                            Stock productStockUpdate = stock;
                            await _stockRepository.UpdateStockAsync(productStockUpdate);
                        }
                      
                    }
                }

                return new ResponseResult { IsSucceeded = true, ApiStatusCode = 200, ReturnData = _mapper.Map<TransferOutModel>(transferOut) };
           
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                return new ResponseResult { IsSucceeded = false, ApiStatusCode = 400, ErrorMessage = ex.ToString() };

            }

            //var supplier = _supplierRepository.GetSupplierById(transferInModel.SupplierId);
            //if (supplier == null)
            //    return null;

        }
        #endregion

        #region Get  
        private string AvalabliteProducts(List<TransferOutDetail> transferOutDetails)
        {
            string result = "";
            var query = transferOutDetails.GroupBy(x => new { x.VarientCode, x.ProductVarientId }).Select
                (s => new TransferOutDetail
                {
                    VarientCode = s.Key.VarientCode,
                    ProductVarientId = s.Key.ProductVarientId,
                    Qty = s.Sum(s => s.Qty)

                }).ToList();
            foreach (var item in query)
            {
                var stock = _stockRepository.GetStockByProductId(item.ProductVarientId);
                if (stock == null)
                {
                    result += String.Format("هذا المنتج برمز {0} ليس له مخزون.\n ", (item == null ? "0" : item.VarientCode));
                }
                else if (stock.PhysicalStock < item.Qty)
                    result += String.Format("هذا المنتج برمز {0}\n" +
                        "الحد الأقصى للمخزون المتاح {1} ليس {2}.\n", (item ==null ? "0":item.VarientCode) ,(stock==null ? 0:stock.PhysicalStock), (item == null ? 0 : item.Qty));
            }
                return result;
        }
        public bool IsAcceptProduct(string code)
        {
            var product = _productRepository.GetProductByCode(code);
            if (product == null)
                return false;
            else
                return true;
        }
        private ProductVarient getproductByCode(string code)
        {
            return _productRepository.GetProductByCode(code);
        }
        private ProductVarient getproductByRfid(string rfid)
        {
            return _productRepository.GetProductByRFID(rfid);
        }

        public async Task<IEnumerable<TransferOut>> GetAllTransferOuts()
        {
            return await _transferOutRepository.GetAllTransferOut();
        }
        public async Task<TransferOut> GetTransferOutById(int id)
        {
            var transferOut =  await _transferOutRepository.GetTransferOutById(id);
            return transferOut;
        }
        #endregion

        #region Update
        #endregion


    }
}
