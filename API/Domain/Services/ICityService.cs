using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Services
{
    public interface ICityService
    {
         Task<IEnumerable<City>> ListAsync();
    }
}