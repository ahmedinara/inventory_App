using IMS.Core.Entities;
using IMS.Core.Repository;
using IMS.Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Data.Repository
{
    public class MeasuringUnitRepository : IMeasuringUnitRepository
    {
        private readonly AppDbContext _dbContext;

        public MeasuringUnitRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add

        #endregion

        #region Get
       
        public async Task<MeasuringUnit> GetMeasuringUnitById(int id)
        {
            return await _dbContext.MeasuringUnits.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<MeasuringUnit>> GetAllMeasuringUnits()
        {
            return await _dbContext.MeasuringUnits.ToListAsync();
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
