using System.Collections.Generic;

namespace API.Domain.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Trip> Trips { get; set; } = new List<Trip>();
    }
}