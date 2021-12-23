using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Repository
{
    public interface ITransferInRepository
    {
        #region Add
        Task<TransferIn> AddTransferIn(TransferIn transferIn);
        #endregion

        #region Get  
        Task<TransferIn> GetTransferInById(int id);
        Task<IEnumerable<TransferIn>> GetAllTransferIn();
        Task<bool> GetTransferInByInvoiceNo(string invoiceNo);
        #endregion

        #region Update
        #endregion
    }
}
