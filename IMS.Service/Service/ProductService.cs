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

namespace IMS.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public ProductService(IProductRepository productRepository,
            IScannedProductRepository rfIdScannedProductRepository,
                            ILocationRepository locationRepository,IMapper mapper,IStockRepository stockRepository)
        {
            _productRepository = productRepository;
            _locationRepository = locationRepository;
            _mapper = mapper;
            _stockRepository = stockRepository;
        }

        #region Add
        public async Task<ProductMasterModel> AddProduct(ProductMasterModel productMasterModel,int userId)
        {
            var productMaster = _mapper.Map<ProductMaster>(productMasterModel);
            productMaster.CreatedBy = userId;
            productMaster.CreatedOn = DateTime.Now;
            productMaster.IsDeleted = false;
            if (await _productRepository.isExistsProductCode(productMaster.Code,0))
                return null;

            var entity = await _productRepository.AddProductMaster(productMaster);
            
            return _mapper.Map<ProductMasterModel>(entity);
        }
        #endregion

        #region Get       
        public async Task<IEnumerable<ProductMaster>> GetProducts()
        {
            try
            {
                
                var products = await _productRepository.GetAllProducts();

                return products;
            }
            catch (Exception ex)
            {
                var e =ex.ToString();
                return null;
            }
        }
        public async Task<IEnumerable<ProductMasterModel>> GetProductModels()
        {
            try
            {

                var products = await _productRepository.GetAllProducts();

                return _mapper.Map<IEnumerable<ProductMasterModel>>(products);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                return null;
            }
        }
        public ProductMaster GetProductById(int id)
        {
            var product =  _productRepository.GetProductById(id);
            return product;
        }
        public ProductVarient GetProductByCode(string code)
        {
            return _productRepository.GetProductByCode(code);
            
        }
        public async Task<IEnumerable<ProductMaster>> GetAllProductDlls()
        {
            return await _productRepository.GetAllProductDlls();
        }
        #endregion

        #region Update
        public async Task<ProductMasterModel> updateProduct(ProductMasterModel productMasterModel,int productId, int userId)
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null)
                return null;
            if (await _productRepository.isExistsProductCode(productMasterModel.Code, productId))
                return null;

            var productMaster = _mapper.Map<ProductMaster>(productMasterModel);
              productMaster.LastUpdateBy = userId;
            productMaster.LastUpdateOn = DateTime.Now;

          
            var entity = await _productRepository.UpdateProductMaster(productMaster);

            return _mapper.Map<ProductMasterModel>(entity);
        }
        #endregion


    }
}
