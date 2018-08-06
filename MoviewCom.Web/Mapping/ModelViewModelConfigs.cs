using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieCom.Service.Models;
using MovieCom.Web.Models.Movie;

namespace MoviewCom.Web.Mapping
{
    public class ModelToViewModelConfig : Profile
    {

    }

    public class ViewModelToModel : Profile
    {
        public ViewModelToModel()
        {
            CreateMap<AddMovieViewModel, MovieModel>();
        }
    }
}