using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Repository
{
    public interface IStockRepository
    {
        #region Add
        Task<Stock> AddStock(Stock stock);
        #endregion

        #region Get 
        Task<IEnumerable<Stock>> GetStockProducts();
        Task<Stock> GetStockById(int id);
        Stock GetStockByProductId(int productId);
        Task<Stock> GetStockByProductIdAsync(int productId);
        #endregion

        #region Update
        Task<Stock> UpdateStockAsync(Stock stock);
        #endregion

    }
}
