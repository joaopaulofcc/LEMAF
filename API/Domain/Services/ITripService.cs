using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Services
{
    public interface ITripService
    {
         Task<IEnumerable<Trip>> ListAsync();

         Task<IEnumerable<Trip>> FindByCityAsync(int id);
    }
}