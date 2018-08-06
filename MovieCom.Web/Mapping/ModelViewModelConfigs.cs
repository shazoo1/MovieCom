using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieCom.Service.Models;
using MovieCom.Web.Models.Actors;
using MovieCom.Web.Models.Movie;

namespace MoviewCom.Web.Mapping
{
    public class ModelToViewModel : Profile
    {
        public ModelToViewModel()
        {
            CreateMap<MovieModel, AddMovieViewModel>();
            CreateMap<ActorModel, EditActorViewModel>();
        }
    }

    public class ViewModelToModel : Profile
    {
        public ViewModelToModel()
        {
            CreateMap<AddMovieViewModel, MovieModel>();
            CreateMap<EditActorViewModel, ActorModel>();
        }
    }
}