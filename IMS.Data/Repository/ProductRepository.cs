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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add
        public async Task<ProductMaster> AddProductMaster(ProductMaster productMaster)
        {
            try
            {
                var entity = await _dbContext.ProductMasters.AddAsync(productMaster);
                await Commit();
                return entity.Entity;
            }
            catch (Exception ex)
            {
                var x = ex.ToString();
                return null;
            }
        }
        public async Task<List<ProductVarient>> AddProductVarients(List<ProductVarient> productMasters)
        {
            try
            {
                await _dbContext.ProductVarients.AddRangeAsync(productMasters);
                await Commit();
                return productMasters;
            }
            catch (Exception ex)
            {
                var x = ex.ToString();
                return null;
            }
        }

        #endregion

        #region Get
        public async Task<IEnumerable<ProductMaster>> GetAllProducts()
        {
            return await _dbContext.ProductMasters
                .Include(p=>p.Category)
                .Include(p=>p.CreatedByNavigation)
                .Include(p=>p.MeasuringUnit)
                .OrderByDescending(o=>o.Id)
                .ToListAsync();
        }
        public async Task<IEnumerable<ProductMaster>> GetAllProductDlls()
        {
            return await _dbContext.ProductMasters
                .Select(s => new ProductMaster { Id = s.Id
                , TitleAr=s.TitleAr})
                .OrderByDescending(o => o.Id)
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

        public ProductMaster GetProductById(int id)
        {
            return  _dbContext.ProductMasters.Include(x=>x.ProductVarients).FirstOrDefault(p=>p.Id==id);
        }

        public ProductVarient GetProductByCode(string code)
        {
            return _dbContext.ProductVarients.AsNoTracking().FirstOrDefault(p => p.VarientCode == code);
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
            return await _dbContext.ProductMasters.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> isExistsProductCode(string code,int productid)
        {
            return await _dbContext.ProductMasters.AnyAsync(p => p.Code == code&& p.Id != productid);
        }
        #endregion

        #region Update
        public async Task<ProductMaster> UpdateProductMaster(ProductMaster productMaster)
        {
            try
            {
                var entity =  _dbContext.ProductMasters.Update(productMaster);
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
