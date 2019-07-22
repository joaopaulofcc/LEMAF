using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Domain.Services;

namespace API.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
    
        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<IEnumerable<Trip>> ListAsync()
        {
            return await _tripRepository.ListAsync();
        }

        public async Task<IEnumerable<Trip>> FindByCityAsync(int id)
        {
            return await _tripRepository.FindByCityAsync(id);
        }
    }
}