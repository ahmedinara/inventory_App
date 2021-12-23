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
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository,
                          IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        #region Add
     
        #endregion

        #region Get       
        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await _locationRepository.GetAllLocations();
        }

        public async Task<Location> GetLocationById(int id)
        {
            var location =  await _locationRepository.GetLocationById(id);
            return location;
        }
        #endregion

        #region Update
     
        #endregion


    }
}
