using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Repositories
{
    public interface ITripRepository
    {
         Task<IEnumerable<Trip>> ListAsync();

         Task<IEnumerable<Trip>> FindByCityAsync(int id);
    }
}