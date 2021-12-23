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
    public class ProductVareintService : IProductVareintService
    {
        private readonly IProductVarientRepository _productVarientRepository;
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;

        public ProductVareintService(IProductVarientRepository productVarientRepository,
            IScannedProductRepository rfIdScannedProductRepository,
                            IMapper mapper,IStockRepository stockRepository)
        {
            _productVarientRepository = productVarientRepository;
            _mapper = mapper;
            _stockRepository = stockRepository;
        }

        #region Add
        public async Task<ProductVarientModel> AddProduct(ProductVarientModel productVarientModel)
        {
            var productVarient = _mapper.Map<ProductVarient>(productVarientModel);
            productVarient.CreatedOn = DateTime.Now;

            if (await _productVarientRepository.isExistsProductCode(productVarient.VarientCode,0))
                return null;

            if (await _productVarientRepository.isExistsRfidCode(productVarient.RfidCode, 0))
                return null;

            var entity = await _productVarientRepository.AddProductVarient(productVarient);
            
            return _mapper.Map<ProductVarientModel>(entity);
        }
        #endregion

        #region Get       
        public async Task<IEnumerable<ProductVarientWithParentModel>> GetProducts()
        {
            try
            {
                
                var products = await _productVarientRepository.GetAllProductVarients();

                return _mapper.Map<IEnumerable<ProductVarientWithParentModel>>(products);
            }
            catch (Exception ex)
            {
                var e =ex.ToString();
                return null;
            }
        }
     
        public async Task<ProductVarientWithParentModel> GetProductById(int id)
        {
            var product =await  _productVarientRepository.GetProductWithJoinById(id);
            return _mapper.Map<ProductVarientWithParentModel>(product);
        }

        public ProductVarient GetProductByCode(string code)
        {
            return _productVarientRepository.GetProductVarientByCode(code);
            
        }
        public ProductVarient GetProductByRFID(string code)
        {
            return _productVarientRepository.GetProductByRFID(code);

        }
        #endregion

        #region Update
        public async Task<ProductVarientModel> updateProduct(ProductVarientModel productVarientModel,int productId, int userId)
        {
            var product = await _productVarientRepository.GetProductById(productId);
            if (product == null)
                return null;
            if (await _productVarientRepository.isExistsProductCode(productVarientModel.VarientCode, productId))
                return null;
            if (await _productVarientRepository.isExistsRfidCode(productVarientModel.RfidCode, productId))
                return null;

            var productVarient = _mapper.Map<ProductVarient>(productVarientModel);
             

          
            var entity = await _productVarientRepository.UpdateProductVarient(productVarient);

            return _mapper.Map<ProductVarientModel>(entity);
        }
        #endregion


    }
}
