using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Repository
{
    public interface IProductRepository
    {
        #region Add
        Task<ProductMaster> AddProductMaster(ProductMaster productMaster);
        Task<List<ProductVarient>> AddProductVarients(List<ProductVarient> productMasters);
        #endregion

        #region Get  
        Task<IEnumerable<ProductMaster>> GetAllProducts();
        ProductMaster GetProductById(int id);
        Task<bool> isExistsProductById(int id);
        Task<bool> isExistsProductCode(string code, int productid);
        Task<IEnumerable<ProductVarient>> GetAllProductsHasStock(DateTime dateTime);
            ProductVarient GetProductByRFID(string rFid);
        ProductVarient GetProductVarientByCode(string code);
        ProductVarient GetProductByCode(string code);
        Task<IEnumerable<ProductMaster>> GetAllProductDlls();
        #endregion

        #region Update
        Task<ProductMaster> UpdateProductMaster(ProductMaster productMaster);
        #endregion
    }
}
