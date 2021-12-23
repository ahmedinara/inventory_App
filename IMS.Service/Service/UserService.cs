using AutoMapper;
using IMS.Core.Entities;
using IMS.Core.Models;
using IMS.Core.Repository;
using IMS.Core.Service;
using IMS.Core.Shared;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Service
{
    public class UserService : IUserService
    {      
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper,IUserRepository userRepository,IAuthService authService)
        {
           _userRepository = userRepository;
            _authService = authService;
            _mapper = mapper;
        }

        #region Add
        public async Task<User> AddUser(User user)
        {
            user.Password =  _authService.CreateHashSaltPassword(user.Password, out byte[] salt);
            user.PasswordSalt = salt;
            user.CreatedOn = DateTime.Now;
            user.CompanyId = 1;
            var entity = await _userRepository.AddUser(user);
            return entity;
        }
        #endregion

        #region Add
        public async Task<User> UpdateUser(UserModel userModel,int userId,int updatedUser)
        {
            var user = _mapper.Map<User>(userModel);
            var userExists =await _userRepository.GetUserById(user.Id);
            if (userExists == null)
                return null;
            user.Password = userExists.Password;
            user.PasswordSalt = userExists.PasswordSalt;
            user.CreatedOn = userExists.CreatedOn;
            user.UpdateBy = updatedUser;
            user.UpdatedOn = DateTime.Now;
            user.CompanyId = 1;
            var entity = await _userRepository.UpdateUser(user);
            return entity;
        }
        #endregion

        #region Get
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }
        public async Task <User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }
        public async Task<UserModel> GetUserModelById(int id)
        {
            return  _mapper.Map<UserModel>(await _userRepository.GetUserById(id));
        }
        #endregion



    }
}
