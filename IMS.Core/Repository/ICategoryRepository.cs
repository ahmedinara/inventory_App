using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Repository
{
    public interface ICategoryRepository
    {
        #region Add
        #endregion

        #region Get  
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetAllCategory();
        Task<bool> IsExistsCategory(int id);
        #endregion

        #region Update
        #endregion
    }
}
