using IMS.Core.Entities;
using IMS.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace IMS.Data.Repositories
{
    public class ScannedProductRepository : IScannedProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ScannedProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add
        public async Task<RfIdScannedProduct> AddScannedProducts(RfIdScannedProduct rfIdScannedProduct)
        {
            try
            { 
                var entity=  await _dbContext.RfIdScannedProducts.AddAsync(rfIdScannedProduct);
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
        public async Task<IEnumerable<RfIdScannedProduct>> GetScannedProducts()
        {
            return await _dbContext.RfIdScannedProducts.Include(rfp => rfp.CreatedByNavigation).ToListAsync();

        }

        public async Task<RfIdScannedProduct> GetScannedProductById(int id)
        {
            return await _dbContext.RfIdScannedProducts.Include(rfp=>rfp.CreatedByNavigation).Include(rfp => rfp.ItemScanneds).ThenInclude(x=>x.ProductVarientCodeNavigation).Include(rfp => rfp.ItemScanneds).ThenInclude(d=>d.States).FirstOrDefaultAsync(rfp=>rfp.Id==id); 

        }
        #endregion

        #region Update

        #endregion

        #region Commit
        private async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }
        #endregion

    }
}
