using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Repository
{
    public interface ISupplierRepository
    {
        #region Add
        #endregion

        #region Get  
        Task<Supplier> GetSupplierById(int id);
        Task<IEnumerable<Supplier>> GetAllSuppliers();
        Task<bool> IsExistsSupplier(int id);
        #endregion

        #region Update
        #endregion
    }
}
