using IMS.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Core.Repository
{
    public interface IScannedProductRepository
    {
        #region Add
        Task<RfIdScannedProduct> AddScannedProducts(RfIdScannedProduct rfIdScannedProduct);
        #endregion

        #region Get 
        Task<RfIdScannedProduct> GetScannedProductById(int id);
        Task<IEnumerable<RfIdScannedProduct>> GetScannedProducts();
        #endregion

        #region Update
        #endregion


    }
}
