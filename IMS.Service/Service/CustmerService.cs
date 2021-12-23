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
    public class CustmerService : ICustmerService
    {
        private readonly ICustmerRepository _custmerRepository;
        private readonly IMapper _mapper;

        public CustmerService(ICustmerRepository custmerRepository,
                          IMapper mapper)
        {
            _custmerRepository = custmerRepository;
            _mapper = mapper;
        }

        #region Add

        #endregion

        #region Get       
        public async Task<IEnumerable<CustmerModel>> GetAllCustmers()
        {
            return _mapper.Map<IEnumerable<CustmerModel>>(await _custmerRepository.GetAllCustmers());
        }

        public async Task<CustmerModel> GetCustmerById(int id)
        {
            var custmer = await _custmerRepository.GetCustmerById(id);
            return _mapper.Map<CustmerModel>(custmer);
        }
        #endregion

        #region Update
     
        #endregion


    }
}
