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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add

        #endregion

        #region Get
        public async Task<Category> GetCategoryById(int id)
        {
            return  await _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(p=>p.Id==id);
        }
        public async Task<bool> IsExistsCategory(int id)
        {
            return await _dbContext.Categories.AnyAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _dbContext.Categories.ToListAsync();
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
