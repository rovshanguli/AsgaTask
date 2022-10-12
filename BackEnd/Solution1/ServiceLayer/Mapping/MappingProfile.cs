using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.DTOs.CityDto;
using ServiceLayer.DTOs.CountryDto;
using ServiceLayer.DTOs.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();

            CreateMap<Country, CountryEditDto>().ReverseMap();

            CreateMap<City, CityDto>().ReverseMap();

            CreateMap<City, CityEditDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<Order, OrderEditDto>().ReverseMap();
            CreateMap<Order, OrderGetDto>().ReverseMap();
        }
   
    }
}
