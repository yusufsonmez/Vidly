using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    { 
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>(); // map Customer to CustomerDto
            Mapper.CreateMap<CustomerDto, Customer>(); // map CustomerDto to Customer
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}