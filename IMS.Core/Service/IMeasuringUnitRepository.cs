using IMS.Core.Dtos;
using IMS.Core.Entities;
using IMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Service
{
    public interface IMeasuringUnitRepository
    {
        #region Add

        #endregion

        #region Get 
        Task<MeasuringUnit> GetMeasuringUnitById(int id);
        Task<IEnumerable<MeasuringUnit>> GetAllMeasuringUnits();
        #endregion

        #region Update
        #endregion
    }
}
