using Microsoft.EntityFrameworkCore;
using API.Domain.Models;

namespace API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Mapeia o modelo City
            builder.Entity<City>().ToTable("Cities");
            builder.Entity<City>().HasKey(p => p.Id);
            builder.Entity<City>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<City>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<City>().HasMany(p => p.Trips).WithOne(p => p.City).HasForeignKey(p => p.CityId);

            // Popula as cidades.
            builder.Entity<City>().HasData
            (
                new City { Id = 42, Name = "Lyon" },
                new City { Id = 132, Name = "Dubai" }                 
            );


            // Mapeia o modelo Trip
            builder.Entity<Trip>().ToTable("Trips");
            builder.Entity<Trip>().HasKey(p => p.Id);
            builder.Entity<Trip>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Trip>().Property(p => p.Thumb).IsRequired();
            builder.Entity<Trip>().Property(p => p.HotelName).IsRequired().HasMaxLength(50);
            builder.Entity<Trip>().Property(p => p.Stars).IsRequired();
            builder.Entity<Trip>().Property(p => p.Location).IsRequired();
            builder.Entity<Trip>().Property(p => p.Country).IsRequired();
            builder.Entity<Trip>().Property(p => p.Date).IsRequired();
            builder.Entity<Trip>().Property(p => p.Price).IsRequired();
            builder.Entity<Trip>().Property(p => p.Class).IsRequired();
            builder.Entity<Trip>().Property(p => p.Guest).IsRequired();

            // Popula as viagens.
            // Alterei as datas originais para ter dados que possam ser exibidos
            // no frontend.
            builder.Entity<Trip>().HasData
            (
                new Trip
                {
                    Id = 1,
                    HotelName = "Jumeirah Creekside Hotel",
                    Thumb = "https://loremflickr.com/130/100/dubai",
                    Stars = 5,
                    Location = "Garghoud",
                    CityId = 132,
                    Country = "UAE",
                    //Date = "2019-03-17",
                    Date = "2019-10-17",
                    Price = 800,
                    Class = "First Class",
                    Guest = 1
                },
                new Trip
                {
                    Id = 2,
                    HotelName = "City Premier Hotel Apartments",
                    Thumb = "https://loremflickr.com/130/100/dubai",
                    Stars = 4,
                    Location = "Metro Access",
                    CityId = 132,
                    Country = "UAE",
                    //Date = "2019-03-21",
                    Date = "2019-07-21",
                    Price = 700,
                    Class = "Business Class",
                    Guest = 1
                },
                new Trip
                {
                    Id = 3,
                    HotelName = "Dusit Thani Dubai",
                    Thumb = "https://loremflickr.com/130/100/dubai",
                    Stars = 4,
                    Location = "Trade Centre",
                    CityId = 132,
                    Country = "UAE",
                    Date = "2019-09-30",
                    Price = 750,
                    Class = "First Class",
                    Guest = 1
                },
                new Trip
                {
                    Id = 4,
                    HotelName = "Temple Dubai Business",
                    Thumb = "https://loremflickr.com/130/100/dubai",
                    Stars = 5,
                    Location = "Galley",
                    CityId = 132,
                    Country = "UAE",
                    Date = "2019-01-12",
                    Price = 1270,
                    Class = "First Class",
                    Guest = 1
                },
                new Trip
                {
                    Id = 5,
                    HotelName = "Temple Dubai Business",
                    Thumb = "https://loremflickr.com/130/100/lyon",
                    Stars = 5,
                    Location = "Vieux Lyon",
                    CityId = 42,
                    Country = "France",
                    //Date = "2019-05-22",
                    Date = "2019-11-22",
                    Price = 570,
                    Class = "First Class",
                    Guest = 1
                }
            );
        }
    }
}