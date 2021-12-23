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
    public class ScannedStateRepository : IScannedStateRepository
    {
        private readonly AppDbContext _dbContext;

        public ScannedStateRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add

        #endregion

        #region Get
        public async Task<ScannedState> GetScannedStateById(int id)
        {
            return  await _dbContext.ScannedStates.AsNoTracking().FirstOrDefaultAsync(p=>p.Id==id);
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
