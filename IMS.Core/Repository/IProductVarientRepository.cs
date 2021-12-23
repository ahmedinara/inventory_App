using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Repository
{
    public interface IProductVarientRepository
    {  
        #region Add
        Task<ProductVarient> AddProductVarient(ProductVarient productVarient);
        #endregion

        #region Get
        Task<bool> isExistsRfidCode(string rFID, int productVarientId);

        Task<IEnumerable<ProductVarient>> GetAllProductVarients();

        Task<IEnumerable<ProductVarient>> GetAllProductsHasStock(DateTime dateTime);
        Task<ProductVarient> GetProductWithJoinById(int id);
        Task<ProductVarient> GetProductById(int id);
        ProductVarient GetProductVarientByCode(string code);

        ProductVarient GetProductByRFID(string rFid);

        Task<bool> isExistsProductById(int id);

        Task<bool> isExistsProductCode(string code, int productVarientId);
        #endregion

        #region Update
        Task<ProductVarient> UpdateProductVarient(ProductVarient productVarient);
        #endregion
    }
}
