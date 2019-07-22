using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Domain.Models;
using API.Domain.Services;
using API.Resources;

namespace API.Controllers
{
    [Route("/[controller]")]
    public class TripsController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IMapper _mapper;

        public TripsController(ITripService tripService, IMapper mapper)
        {
            _tripService = tripService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TripResource>> ListAsync()
        {
            var trips = await _tripService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Trip>, IEnumerable<TripResource>>(trips);
            return resources;
        }

        // GET trips/city/5
        [HttpGet("city/{id}")]
        public async Task<IEnumerable<TripResource>> GetByCity(int id)
        {
            var trips = await _tripService.FindByCityAsync(id);
            var resources = _mapper.Map<IEnumerable<Trip>, IEnumerable<TripResource>>(trips);
            return resources;
        }
    }
}