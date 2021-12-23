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
    public class CustmerRepository : ICustmerRepository
    {
        private readonly AppDbContext _dbContext;

        public CustmerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add

        #endregion

        #region Get
        public async Task<Custmer> GetCustmerById(int id)
        {
            return  await _dbContext.Custmers.AsNoTracking().FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IEnumerable<Custmer>> GetAllCustmers()
        {
            return await _dbContext.Custmers.ToListAsync();
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
