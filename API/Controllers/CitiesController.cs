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
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        
        public CitiesController(ICityService categoryService, IMapper mapper)
        {
            _cityService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CityResource>> GetAllAsync()
        {
            var cities = await _cityService.ListAsync();
            var resources = _mapper.Map<IEnumerable<City>, IEnumerable<CityResource>>(cities);
            
            return resources;
        }
    }
}