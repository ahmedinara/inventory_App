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
    public class SuppilerService : ISuppilerService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SuppilerService(ISupplierRepository supplierRepository,
                          IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        #region Add
     
        #endregion

        #region Get       
        public async Task<IEnumerable<SupplierModel>> GetAllSuppliers()
        {
            return _mapper.Map<IEnumerable<SupplierModel>>(await _supplierRepository.GetAllSuppliers());
        }

        public async Task<SupplierModel> GetSupplierById(int id)
        {
            var Supplier =  await _supplierRepository.GetSupplierById(id);
            return _mapper.Map<SupplierModel>(Supplier);
        }
        #endregion

        #region Update
     
        #endregion


    }
}
