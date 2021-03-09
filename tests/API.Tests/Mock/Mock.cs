using AutoMapper;
using CarPark.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mock
{
    public class Mock
    {
        public static IMapper Mapper
        {
            get
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ServiceProfile());
                });

                return mapper.CreateMapper();
            }
        }
    }
}
