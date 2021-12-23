using IMS.Core.Dtos;
using IMS.Core.Entities;
using IMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Service
{
    public interface IProductService
    {
        #region Add
        Task<ProductMasterModel> AddProduct(ProductMasterModel productMasterModel, int userId);
        #endregion

        #region Get 
        Task<IEnumerable<ProductMaster>> GetProducts();
        ProductMaster GetProductById(int id);
        ProductVarient GetProductByCode(string code);
        Task<IEnumerable<ProductMasterModel>> GetProductModels();
        Task<IEnumerable<ProductMaster>> GetAllProductDlls();
        #endregion

        #region Update
        #endregion
    }
}
