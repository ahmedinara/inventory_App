using IMS.Core.Dtos;
using IMS.Core.Entities;
using IMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Service
{
    public interface ITransferInService
    {
        #region Add
        Task<ResponseResult> AddTransferInModel(TransferInModel transferInModel, int userId);
        Task<ResponseResult> AddTransactionInDeskTop(TransactionInDeskTopDto transferInModel, int userId);
        #endregion

        #region Get       
        Task<IEnumerable<TransferIn>> GetAllTransferIns();

       Task<TransferIn> GetTransferInById(int id);
        #endregion

        #region Update
        #endregion
    }
}
