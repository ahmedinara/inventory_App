using IMS.Core.Entities;
using IMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Service
{
    public interface IUserService
    {
        #region Add
        Task<User> AddUser(User user);
        #endregion

        #region Get  
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<UserModel> GetUserModelById(int id);
        #endregion

        #region Update
        Task<User> UpdateUser(UserModel userModel, int userId, int updatedUser);
        #endregion
    }
}
