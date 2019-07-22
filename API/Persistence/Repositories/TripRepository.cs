using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Domain.Models;
using API.Domain.Repositories;
using API.Persistence.Contexts;
using System;

namespace API.Persistence.Repositories
{
    public class TripRepository : BaseRepository, ITripRepository
    {
        public TripRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Trip>> ListAsync()
        {
            return await _context.Trips.Include(p => p.City).ToListAsync();
        }

        public async Task<Trip> FindByIdAsync(int id)
        {
            return await _context.Trips
                                 .Include(p => p.City)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }


        static Predicate<Trip> ByCityId(int id)
        {
            return delegate(Trip trip)
            {
                return trip.CityId == id;
            };
        }

        static Predicate<Trip> ByFutureDate()
        {
            return delegate(Trip trip)
            {
                DateTime newDate = DateTime.ParseExact(trip.Date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                DateTime todayDate = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                
                return todayDate <= newDate;
            };
        }

        public async Task<IEnumerable<Trip>> FindByCityAsync(int id)
        {
            var trips = await _context.Trips
                                 .Include(p => p.City)
                                 .ToListAsync();

            var filteredByDate = trips.FindAll(ByFutureDate());
            var filteredByCity = filteredByDate.FindAll(ByCityId(id));

           
            return filteredByCity;
        }
        
    }
}