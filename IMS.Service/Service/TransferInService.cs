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
    public class TransferInService : ITransferInService
    {
        private readonly ITransferInRepository _transferInRepository;
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStockRepository _stockRepository;
        private readonly ICategoryRepository _categoryRepository;
        public TransferInService(ITransferInRepository transferInRepository,
                          IMapper mapper, ISupplierRepository supplierRepository,IProductRepository productRepository,
                          IStockRepository stockRepository,
                          ICategoryRepository categoryRepository)
        {
            _transferInRepository = transferInRepository;
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
            _stockRepository = stockRepository;
            _categoryRepository = categoryRepository;
        }
        //TransactionInDeskTopDto
        #region Add
        public async Task<ResponseResult> AddTransferInModel(TransferInModel transferInModel, int userId)
        {
            var transactionIn = _mapper.Map<TransferIn>(transferInModel);

            var checkResult = await CheckData(transactionIn);
            if (!checkResult.IsSucceeded)
                return checkResult;
        
            var result =await AddTransaction(transactionIn, userId);
            return result;
        }
        public async Task<ResponseResult> AddTransactionInDeskTop(TransactionInDeskTopDto transferInModel, int userId)
        {
            #region Mapping
            transferInModel.ItemsCount = transferInModel.TransferInDetails.Count();
            var transferIn = _mapper.Map<TransferIn>(transferInModel);
            #endregion

            #region Check  
            var checkResult = await CheckData(transferIn);
            if (!checkResult.IsSucceeded)
                return checkResult;

            List<ProductVarient> newProductVarients = new List<ProductVarient>();
            bool IsValidProduct = true;
            var product = _productRepository.GetProductById(transferInModel.ProductId);
            if (product == null)
            {
                product = new ProductMaster { MeasuringUnitId=1, IsDeleted = false, CreatedBy = userId, CategoryId = transferInModel.CategoryId.Value, TitleAr = transferInModel.TitleAr, TitleEn = transferInModel.TitleEn,Code=transferInModel.Code };
                var isExistsCategory = await _categoryRepository.IsExistsCategory(product.CategoryId);
                if(!isExistsCategory)
                    return new ResponseResult { IsSucceeded = false, ApiStatusCode = 400, ErrorMessage = "Invalid Category" };

                var isExaistsProduct = await _productRepository.isExistsProductCode(product.Code, product.Id);
                if(!isExaistsProduct)
                product = await _productRepository.AddProductMaster(product);
                if(product==null)
                    return new ResponseResult { IsSucceeded = false, ApiStatusCode = 400, ErrorMessage = "Invalid Product" };
            }
            #endregion

         
            transferInModel.TransferInDetails.ToList().ForEach(td => {
                IsValidProduct = false;
                if (!string.IsNullOrEmpty(td.TagValue))
                {
                    ProductVarient productVarient = getproductByRdid(td.TagValue);
                    if (productVarient != null)
                    {
                        td.ProductVarientId = productVarient.Id;
                        td.VarientCode = productVarient.VarientCode;
                    }
                    else { IsValidProduct = true; newProductVarients.Add(new ProductVarient { VarientCode = td.TagValue, RfidCode = td.TagValue, ProductId = product.Id, CombinedAttributeId = 1, CreatedOn = DateTime.UtcNow }); }

                }
                if (td.ProductVarientId == 0 && !string.IsNullOrEmpty(td.VarientCode) && !IsValidProduct)
                {
                    ProductVarient productVarient = getproductByCode(td.VarientCode);
                    if (productVarient != null)
                    {
                        td.ProductVarientId = productVarient.Id;
                        td.VarientCode = productVarient.VarientCode;
                    }
                    else { IsValidProduct = true; newProductVarients.Add(new ProductVarient { VarientCode = td.TagValue, RfidCode = td.TagValue, ProductId = product.Id, CombinedAttributeId = 1, CreatedOn = DateTime.UtcNow }); }
                }
            });
            if (newProductVarients.Any())
            {

                var Result = await _productRepository.AddProductVarients(newProductVarients);
                if (Result == null)
                    return new ResponseResult { IsSucceeded = false, ApiStatusCode = 400, ErrorMessage = "Invalid Product" };
            }

            return await AddTransaction(transferIn, userId);
        }
        #endregion

        #region Get     
        private ProductVarient getproductByCode(string code)
        {
            return _productRepository.GetProductByCode(code);
        }
        private ProductVarient getproductByRdid(string rfid)
        {
            return _productRepository.GetProductByRFID(rfid);
        }
        public async Task<IEnumerable<TransferIn>> GetAllTransferIns()
        {
            return await _transferInRepository.GetAllTransferIn();
        }

        public async Task<TransferIn> GetTransferInById(int id)
        {
            var transferIn =  await _transferInRepository.GetTransferInById(id);
            return transferIn;
        }
        #endregion

        #region Update

        #endregion

        #region Private Functions
        private async Task<ResponseResult> AddTransaction(TransferIn TransferIn, int userId)
        {
            try
            {
         
                #region Get Product Ids
                bool IsValidProduct = true;
                TransferIn.ItemsCount = TransferIn.TransferInDetails.Count();
                foreach (var td in TransferIn.TransferInDetails)
                {
                    if (!string.IsNullOrEmpty(td.TagValue))
                    {
                        ProductVarient productVarient = getproductByRdid(td.TagValue);
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
                }
                if (!IsValidProduct)
                    return new ResponseResult { IsSucceeded = false, ApiStatusCode = 400, ErrorMessage = "Invalid Product" };
                #endregion

                #region Saving Transaction Data
                TransferIn.CreatedBy = userId;
                TransferIn.CreatedOn = DateTime.Now;
                var entity = await _transferInRepository.AddTransferIn(TransferIn);
                #endregion

                #region Saving Stocks
                foreach (TransferInDetail transferInDetail in entity.TransferInDetails)
                {
                    var stock = await _stockRepository.GetStockByProductIdAsync(transferInDetail.ProductVarientId);

                    if (stock == null)
                    {
                        Stock productStockAdd = new Stock()
                        {
                            AvaliableStock = transferInDetail.Qty,
                            PhysicalStock = transferInDetail.Qty,
                            ProductVarientId = transferInDetail.ProductVarientId,
                            ReservedStock = 0,
                            OrderedStock = 0,
                            LocationId = 3,
                            VarientCode = transferInDetail.VarientCode
                        };

                        await _stockRepository.AddStock(productStockAdd);
                    }
                    else
                    {
                        stock.PhysicalStock += transferInDetail.Qty;
                        Stock productStockUpdate = stock;
                        await _stockRepository.UpdateStockAsync(productStockUpdate);
                    }
                }
                #endregion

                return new ResponseResult { IsSucceeded = true, ApiStatusCode = 200, ReturnData = _mapper.Map<TransferInModel>(entity) }; ;
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                return new ResponseResult { IsSucceeded = false, ApiStatusCode = 400, ErrorMessage = ex.ToString() };
            }
        }
        private async Task<ResponseResult> CheckData(TransferIn TransferIn)
        {
            var isExistsSupplier = await _supplierRepository.IsExistsSupplier(TransferIn.SupplierId);
            if (!isExistsSupplier)
                return new ResponseResult { IsSucceeded = false, ApiStatusCode = 400, ErrorMessage = "Invalid Supplier" };
            if (TransferIn.TransferInDetails.Count() == 0)
                return new ResponseResult { IsSucceeded = false, ApiStatusCode = 400, ErrorMessage = "Error Empty List" };
         
            return new ResponseResult { IsSucceeded = true, ApiStatusCode = 20};

        }
        #endregion

    }
}
