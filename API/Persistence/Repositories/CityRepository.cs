using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Persistence.Contexts;

namespace API.Persistence.Repositories
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}