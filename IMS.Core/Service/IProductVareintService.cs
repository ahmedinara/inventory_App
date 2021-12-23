using IMS.Core.Entities;
using IMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Service
{
    public interface IProductVareintService
    {
        #region Add
        Task<ProductVarientModel> AddProduct(ProductVarientModel productVarientModel);
        #endregion

        #region Get       
        Task<IEnumerable<ProductVarientWithParentModel>> GetProducts();

        Task<ProductVarientWithParentModel> GetProductById(int id);

        ProductVarient GetProductByCode(string code);

        ProductVarient GetProductByRFID(string code);
        #endregion

        #region Update
        Task<ProductVarientModel> updateProduct(ProductVarientModel productVarientModel, int productId, int userId);
        #endregion
    }
}
