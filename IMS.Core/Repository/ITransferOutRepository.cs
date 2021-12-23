using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Repository
{
    public interface ITransferOutRepository
    {
        #region Add
        Task<TransferOut> AddTransferOut(TransferOut transferOut);
        #endregion

        #region Get
        Task<TransferOut> GetTransferOutById(int id);
        Task<IEnumerable<TransferOut>> GetAllTransferOut();
        #endregion

        #region Update

        #endregion

    }
}
