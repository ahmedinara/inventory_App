using IMS.Core.Entities;
using IMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Service
{
    public interface ITransferOutService
    {
        #region Add
        Task<ResponseResult> AddTransferOutModel(TransferOutModel transferOutModel, int userId);
        #endregion

        #region Get     
        Task<IEnumerable<TransferOut>> GetAllTransferOuts();
        bool IsAcceptProduct(string code);
        Task<TransferOut> GetTransferOutById(int id);
        #endregion

        #region Update

        #endregion
    }
}
