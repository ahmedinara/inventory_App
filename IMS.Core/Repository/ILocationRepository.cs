using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Repository
{
    public interface ILocationRepository
    {
        #region Add
        #endregion

        #region Get  
        Location GetLocationByCode(string code);
        Task<Location> GetLocationById(int id);
        Task<IEnumerable<Location>> GetAllLocations();
        #endregion

        #region Update
        #endregion
    }
}
