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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _dbContext;

        public SupplierRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add

        #endregion

        #region Get
        public async Task<Supplier> GetSupplierById(int id)
        {
            return  await _dbContext.Suppliers.AsNoTracking().FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return await _dbContext.Suppliers.ToListAsync();
        }
        public async Task<bool> IsExistsSupplier(int id)
        {
            return await _dbContext.Suppliers.AnyAsync(s => s.Id == id);
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
