using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Domain.Services;

namespace API.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            this._cityRepository = cityRepository;
        }

        public async Task<IEnumerable<City>> ListAsync()
        { 
            return await _cityRepository.ListAsync();
        }
    }
}