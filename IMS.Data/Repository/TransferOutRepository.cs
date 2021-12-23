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
    public class TransferOutRepository : ITransferOutRepository
    {
        private readonly AppDbContext _dbContext;

        public TransferOutRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add
        public async Task<TransferOut> AddTransferOut(TransferOut transferOut)
        {
            try
            {
                var entity = await _dbContext.TransferOuts.AddAsync(transferOut);
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

        public async Task<TransferOut> GetTransferOutById(int id)
        {
            return  await _dbContext.TransferOuts
                .Include(t=>t.CreatedByNavigation)
                .Include(t=>t.Custmer)
                .Include(t=>t.TransferOutDetails)
                .ThenInclude(td=>td.ProductVarient).ThenInclude(p=>p.Product).AsNoTracking().FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IEnumerable<TransferOut>> GetAllTransferOut()
        {
            return await _dbContext.TransferOuts.Include(c=>c.Custmer).Include(c=>c.CreatedByNavigation).OrderByDescending(x=>x.Id).ToListAsync();
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
