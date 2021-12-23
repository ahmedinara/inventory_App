using AutoMapper;
using IMS.Core;
using IMS.Core.Dtos;
using IMS.Core.Entities;
using IMS.Core.Repository;
using IMS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace IMS.Service.Services
{
    public class ScannedProductService : IScannedProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IScannedProductRepository _rfIdScannedProductRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly IScannedStateRepository _scannedStateRepository;

        public ScannedProductService(IProductRepository productRepository,
            IScannedProductRepository rfIdScannedProductRepository,
                            ILocationRepository locationRepository,IMapper mapper,IStockRepository stockRepository,
                            IScannedStateRepository scannedStateRepository)
        {
            _productRepository = productRepository;
            _rfIdScannedProductRepository = rfIdScannedProductRepository;
            _locationRepository = locationRepository;
            _mapper = mapper;
            _stockRepository = stockRepository;
            _scannedStateRepository = scannedStateRepository;
        }

        #region Add
        public async Task<ResponseResult> AddScannedItems(List<ItemScannedModel> itemScannedModels,int userId)
        {
            
            var scannedItems = _mapper.Map<List<ItemScanned>>(itemScannedModels);
            RfIdScannedProduct rfIdScannedProduct = new RfIdScannedProduct();

            rfIdScannedProduct.CreatedBy = userId;
            rfIdScannedProduct.CreatedOn = DateTime.Now;
            rfIdScannedProduct.ItemScanneds = scannedItems;
            rfIdScannedProduct.ItemsCount = rfIdScannedProduct.ItemScanneds.Count;
            foreach (var item in rfIdScannedProduct.ItemScanneds)
            {
                ProductVarient productVarient = new ProductVarient();
                if (!string.IsNullOrEmpty(item.TagValue))
                    productVarient = getproductByRFID(item.TagValue) ;

                if(productVarient == null && !string.IsNullOrEmpty(item.VariantCode))
                    productVarient = getproductByCode(item.VariantCode);

                var location = GetLocationByCode(item.LocationCode);
                item.ProductVarientCode = productVarient == null ? 0 : productVarient.Id;
                item.LocationId = location == null ? 0 : location.Id;
                item.PhysicalStock = productVarient == null ? 0 : productVarient.Stocks.FirstOrDefault()==null ?0 : productVarient.Stocks.FirstOrDefault().PhysicalStock;
                if (item.PhysicalStock == item.ScannedStock && productVarient != null)
                    item.StatesId = 1;
                else
                    item.StatesId = 2;
            }
         
            var entity = await _rfIdScannedProductRepository.AddScannedProducts(rfIdScannedProduct);
            //ItemScannedModel
            return new ResponseResult { IsSucceeded = true, ApiStatusCode = 200, ReturnData = _mapper.Map<ScannedProductsModel>(entity)};
        }
        #endregion

        #region Get       
        public async Task<IEnumerable<RfIdScannedProduct>> GetRfIdScannedProducts()
        {
            var rfIdScannedProducts = await _rfIdScannedProductRepository.GetScannedProducts();
            
            var rfIdScannedProductdtos = _mapper.Map<IEnumerable<ScannedProductsModel>>(rfIdScannedProducts);
          
            return rfIdScannedProducts.OrderByDescending(o=>o.Id);
        }

        public async Task<RfIdScannedProduct> GetRfIdScannedProductById(int id)
        {
            var rfIdScannedProduct = await _rfIdScannedProductRepository.GetScannedProductById(id);
          
            //rfIdScannedProduct.ItemScanneds.ToList().ForEach(x => x.ProductVarientCodeNavigation =(getproductByCode(x.VariantCode)));
            //rfIdScannedProduct.ItemScanneds.ToList().ForEach(x => x.Location = (GetLocationByCode(x.LocationCode)));
            //rfIdScannedProduct.ItemScanneds.ToList().ForEach()
            rfIdScannedProduct.ItemScanneds =await ItemScannedsGroupByProductId(rfIdScannedProduct.ItemScanneds.ToList());
            rfIdScannedProduct.ItemScanneds.OrderByDescending(o=>o.Id);
            var product = await _productRepository.GetAllProductsHasStock(rfIdScannedProduct.CreatedOn);
            var productIsNotScanned = product.Where(pno => !rfIdScannedProduct.ItemScanneds.Select(i => i.ProductVarientCode).Contains(pno.Id));
            foreach (var item in productIsNotScanned)
            {
                ItemScanned itemScanned = new ItemScanned();
                itemScanned.PhysicalStock = item.Stocks.FirstOrDefault().PhysicalStock;
                itemScanned.ScannedStock = 0;
                itemScanned.StatesId = 4;
                itemScanned.ProductVarientCodeNavigation = item;
                itemScanned.VariantCode = item.VarientCode;
                itemScanned.TagValue = item.RfidCode;
                itemScanned.ScannedId = rfIdScannedProduct.Id;
                itemScanned.States= await _scannedStateRepository.GetScannedStateById(4);
                rfIdScannedProduct.ItemScanneds.Add(itemScanned);
            }
            return rfIdScannedProduct;
        }

        private async Task<List<ItemScanned>> ItemScannedsGroupByProductId(List<ItemScanned> itemScanneds)
        {
            List<ItemScanned> itemScannedsGrouped = new List<ItemScanned>();
            foreach (var item in itemScanneds)
            {
                var ExitesItem = itemScannedsGrouped.FirstOrDefault(i => i.ProductVarientCodeNavigation.VarientCode == item.ProductVarientCodeNavigation.VarientCode && i.ProductVarientCodeNavigation.VarientCode != null);
                if (ExitesItem == null)
                {
                    itemScannedsGrouped.Add(item);
                    ExitesItem = itemScannedsGrouped.FirstOrDefault(i => i.VariantCode == item.VariantCode);
                }
                else
                {
                    ExitesItem.ScannedStock += item.ScannedStock;
                }
                if (ExitesItem.ScannedStock == ExitesItem.PhysicalStock && ExitesItem.ProductVarientCodeNavigation.VarientCode != null)
                    ExitesItem.StatesId = 1;
                else if(ExitesItem.ProductVarientCodeNavigation == null)
                     ExitesItem.StatesId = 3;
                else
                    ExitesItem.StatesId = 2;
                ExitesItem.States = await _scannedStateRepository.GetScannedStateById(ExitesItem.StatesId);
            }
            return  itemScannedsGrouped.ToList();
        }

        private ProductMaster getproductById(int id)
        {
            return  _productRepository.GetProductById(id);
        }

        private Stock GetStockByProductId(int productId)
        {
            return  _stockRepository.GetStockByProductId(productId);
        }

        private Location GetLocationByCode(string code)
        {
            return _locationRepository.GetLocationByCode(code);
        }

        private ProductVarient getproductByCode(string code)
        {
            return _productRepository.GetProductVarientByCode(code);
        }

        private ProductVarient getproductByRFID(string rFID)
        {
            return _productRepository.GetProductByRFID(rFID);
        }

        #endregion

        #region Update

        #endregion


    }
}
