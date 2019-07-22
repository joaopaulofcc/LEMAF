namespace API.Domain.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Thumb { get; set; }
        public string HotelName { get; set; }
        public byte Stars { get; set; }
        public string Location { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public string Country { get; set; }
        public string Date { get; set; }
        public float Price { get; set; }
        public string Class { get; set; }
        public byte Guest { get; set; }
        
    }
}