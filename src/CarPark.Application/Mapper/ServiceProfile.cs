using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using CarPark.Application.ApplicationUsers;
using CarPark.Domain.ApplicationUsers;

namespace CarPark.Application.Mapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<ApplicationUserDto, ApplicationUser>();
            CreateMap<ApplicationUser, ApplicationUserDto>();
        }
    }
}
