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
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _dbContext;

        public LocationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add

        #endregion

        #region Get
        public Location GetLocationByCode(string code)
        {
            return  _dbContext.Locations.AsNoTracking().FirstOrDefault(p=>p.LocationCode==code);
        }
        public async Task<Location> GetLocationById(int id)
        {
            return await _dbContext.Locations.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await _dbContext.Locations.ToListAsync();
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
