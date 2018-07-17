using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieCom.Domain.Models.Entities;
using MovieCom.Service.Models;

namespace MovieCom.Service.Mapping
{
    public class EntityToModel : Profile
    {
        public EntityToModel() {
            CreateMap<Actor, ActorModel>();
            CreateMap<Comment, CommentModel>();
            CreateMap<Genre, GenreModel>();
            CreateMap<Grade, GradeModel>();
            CreateMap<Media, MediaModel>();
            CreateMap<Movie, MovieModel>();
        }
    }
    
    public class ModelToEntity : Profile
    {
        public ModelToEntity()
        {
            CreateMap<ActorModel, Actor>();
            CreateMap<CommentModel, Comment>();
            CreateMap<GenreModel, Genre>();
            CreateMap<GradeModel, Grade>();
            CreateMap<MediaModel, Media>();
            CreateMap<MovieModel, Movie>();
        }
    }
}
