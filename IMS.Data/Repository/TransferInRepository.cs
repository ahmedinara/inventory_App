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
    public class TransferInRepository : ITransferInRepository
    {
        private readonly AppDbContext _dbContext;

        public TransferInRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add
        public async Task<TransferIn> AddTransferIn(TransferIn transferIn)
        {
            try
            {
                var entity = await _dbContext.TransferIns.AddAsync(transferIn);
                await Commit();
                return entity.Entity;
            }
            catch (Exception ex)
            {
                var 
                    x = ex.ToString();
                return null;
            }
        }
        #endregion

        #region Get

        public async Task<TransferIn> GetTransferInById(int id)
        {
            return  await _dbContext.TransferIns
                .Include(t=>t.CreatedByNavigation)
                .Include(t=>t.Supplier)
                .Include(t=>t.TransferInDetails)
                .ThenInclude(td=>td.ProductVarient).ThenInclude(p=>p.Product).AsNoTracking().FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<bool> GetTransferInByInvoiceNo(string invoiceNo)
        {
            return await _dbContext.TransferIns
               .AsNoTracking().AnyAsync(p => p.InvoiceNo == invoiceNo);
        }

        public async Task<IEnumerable<TransferIn>> GetAllTransferIn()
        {
            return await _dbContext.TransferIns.Include(s=>s.Supplier).Include(c=>c.CreatedByNavigation).OrderByDescending(x => x.Id).ToListAsync();
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
