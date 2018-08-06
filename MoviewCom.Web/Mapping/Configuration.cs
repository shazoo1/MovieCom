using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieCom.Service.Mapping;
using MoviewCom.Web.Mapping;

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
                cfg.AddProfile(new ViewModelToModel());
            });
        }

        public static IMapper CreateMapper() => new Mapper(Create());
    }
}