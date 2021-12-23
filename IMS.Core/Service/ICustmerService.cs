using IMS.Core.Dtos;
using IMS.Core.Entities;
using IMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Service
{
    public interface ICustmerService
    {
        #region Add
        #endregion

        #region Get 
        Task<IEnumerable<CustmerModel>> GetAllCustmers();
        Task<CustmerModel> GetCustmerById(int id);
        #endregion

        #region Update
        #endregion
    }
}
