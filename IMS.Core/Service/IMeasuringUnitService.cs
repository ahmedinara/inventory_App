using IMS.Core.Dtos;
using IMS.Core.Entities;
using IMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Service
{
    public interface IMeasuringUnitService
    {
        #region Add

        #endregion

        #region Get 
        Task<IEnumerable<MeasuringUnit>> GetAllMeasuringUnits();
        Task<MeasuringUnit> GetMeasuringUnitById(int id);
        #endregion

        #region Update
        #endregion
    }
}
