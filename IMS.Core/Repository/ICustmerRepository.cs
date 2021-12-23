using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Repository
{
    public interface ICustmerRepository
    {
        #region Add

        #endregion

        #region Get
        Task<Custmer> GetCustmerById(int id);
        Task<IEnumerable<Custmer>> GetAllCustmers();
        #endregion

        #region Update

        #endregion
    }
}
