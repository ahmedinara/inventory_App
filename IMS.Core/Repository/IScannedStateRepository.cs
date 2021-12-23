using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Repository
{
    public interface IScannedStateRepository
    {
        #region Add
        #endregion

        #region Get  
        Task<ScannedState> GetScannedStateById(int id);
        #endregion

        #region Update
        #endregion
    }
}
