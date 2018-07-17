using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieCom.Service.Mapping;

namespace MovieCom.Web.Mapping
{
    public class Configuration
    {
        public static MapperConfiguration Create()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToModel());
                cfg.AddProfile(new ModelToEntity());
            });
        }

        public static IMapper CreateMapper() => new Mapper(Create());
    }
}