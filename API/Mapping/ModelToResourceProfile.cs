using AutoMapper;
using API.Domain.Models;
using API.Resources;

namespace API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<City, CityResource>();
            CreateMap<Trip, TripResource>();
        }
    }
}