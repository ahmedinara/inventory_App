using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Core.Dtos;
using IMS.Core.Entities;
using IMS.Core.Repository;
using IMS.Core.Service;
using System.Linq;
using System.IO;
using IMS.Core.Models;

namespace IMS.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,
                          IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        #region Add
     
        #endregion

        #region Get       
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategory();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category =  await _categoryRepository.GetCategoryById(id);
            return category;
        }
      

        #endregion

        #region Update

        #endregion


    }
}
