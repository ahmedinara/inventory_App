using IMS.Core.Entities;
using IMS.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Data.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _dbContext;

        public StockRepository(AppDbContext dbContext)
        {
          
            _dbContext = dbContext;
        }

        #region Add
        public async Task<Stock> AddStock(Stock stock)
        {
            try
            {
                var entity = await _dbContext.Stocks.AddAsync(stock);
                await Commit();
                return entity.Entity;
            }
            catch (Exception ex)
            {
                var x = ex.ToString();
                return null;
            }
        }
        #endregion

        #region Get
        public async Task<IEnumerable<Stock>> GetStockProducts()
        {
            return await _dbContext.Stocks.ToListAsync();

        }

        public async Task<Stock> GetStockById(int id)
        {
            return await _dbContext.Stocks.Include(s => s.ProductVarient).AsNoTracking().FirstOrDefaultAsync(rfp => rfp.Id == id);

        }

        public Stock GetStockByProductId(int productId)
        {
            return  _dbContext.Stocks.Include(s => s.ProductVarient).AsNoTracking().FirstOrDefault(rfp => rfp.ProductVarientId == productId);

        }
        public async Task<Stock> GetStockByProductIdAsync(int productId)
        {
            return await _dbContext.Stocks.Include(s => s.ProductVarient).AsNoTracking().FirstOrDefaultAsync(rfp => rfp.ProductVarientId == productId);

        }
        #endregion

        #region Update
        public async Task<Stock> UpdateStockAsync(Stock stock)
        {
            var entity = _dbContext.Stocks.Attach(stock);
            entity.State = EntityState.Modified;
            await Commit();
            return stock;
        }
        #endregion

        #region Commit
        private async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
