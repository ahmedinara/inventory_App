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
    public class MeasuringUnitService : IMeasuringUnitService
    {
        private readonly IMeasuringUnitRepository _measuringUnitRepository;
        private readonly IMapper _mapper;

        public MeasuringUnitService(IMeasuringUnitRepository measuringUnitRepository,
                          IMapper mapper)
        {
            _measuringUnitRepository = measuringUnitRepository;
            _mapper = mapper;
        }

        #region Add
     
        #endregion

        #region Get       
        public async Task<IEnumerable<MeasuringUnit>> GetAllMeasuringUnits()
        {
            return await _measuringUnitRepository.GetAllMeasuringUnits();
        }

        public async Task<MeasuringUnit> GetMeasuringUnitById(int id)
        {
            var location =  await _measuringUnitRepository.GetMeasuringUnitById(id);
            return location;
        }
        #endregion

        #region Update
     
        #endregion


    }
}
