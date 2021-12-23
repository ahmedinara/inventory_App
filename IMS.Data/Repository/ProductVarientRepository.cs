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
    public class ProductVarientRepository : IProductVarientRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductVarientRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add
        public async Task<ProductVarient> AddProductVarient(ProductVarient productVarient)
        {
            try
            {
                var entity = await _dbContext.ProductVarients.AddAsync(productVarient);
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
        public async Task<IEnumerable<ProductVarient>> GetAllProductVarients()
        {
            return await _dbContext.ProductVarients
                .Include(p=>p.Product)
                .Include(p=>p.Stocks)
                .OrderByDescending(o=>o.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductVarient>> GetAllProductsHasStock(DateTime dateTime)
        {
            return await _dbContext.ProductVarients
                .Include(s=>s.Stocks).Include(v=>v.Product)
                .Where(p=>p.CreatedOn <= dateTime && p.Stocks.Count>0)
                .OrderByDescending(o => o.Id)
                .ToListAsync();
        }

        public async Task<ProductVarient> GetProductWithJoinById(int id)
        {
            return await _dbContext.ProductVarients.Include(x=>x.Product).Include(x=>x.Stocks).AsNoTracking().FirstOrDefaultAsync(p=>p.Id==id);
        }
        public async Task<ProductVarient> GetProductById(int id)
        {
            return await _dbContext.ProductVarients.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public ProductVarient GetProductVarientByCode(string code)
        {
       
            return _dbContext.ProductVarients.Include(s=>s.Stocks).Include(p=>p.Product).AsNoTracking().FirstOrDefault(p => p.VarientCode == code);
        }

        public ProductVarient GetProductByRFID(string rFid)
        {
            return _dbContext.ProductVarients.Include(s => s.Stocks).Include(p => p.Product).AsNoTracking().FirstOrDefault(p => p.RfidCode == rFid);
        }

        public async Task<bool> isExistsProductById(int id)
        {
            return await _dbContext.ProductVarients.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> isExistsProductCode(string code,int productVarientId)
        {
            return await _dbContext.ProductVarients.AnyAsync(p => p.VarientCode == code&& p.Id != productVarientId);
        }
        public async Task<bool> isExistsRfidCode(string rFID, int productVarientId)
        {
            return await _dbContext.ProductVarients.AnyAsync(p => p.RfidCode == rFID && p.Id != productVarientId);
        }
        #endregion

        #region Update
        public async Task<ProductVarient> UpdateProductVarient(ProductVarient productVarient)
        {
            try
            {
                var entity =  _dbContext.ProductVarients.Update(productVarient);
                entity.State = EntityState.Modified;
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

        #region Commit
        private async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
