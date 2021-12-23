using IMS.Core.Dtos;
using IMS.Core.Entities;
using IMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Service
{
    public interface ILocationService
    {
        #region Add

        #endregion

        #region Get 
        Task<IEnumerable<Location>> GetAllLocations();
        Task<Location> GetLocationById(int id);
        #endregion

        #region Update
        #endregion
    }
}
