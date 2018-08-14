using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieCom.Domain.Entities.Identity;
using MovieCom.Service.Models;
using MovieCom.Web.Models.Actors;
using MovieCom.Web.Models.Movie;

namespace MoviewCom.Web.Mapping
{
    public class ModelToViewModel : Profile
    {
        public ModelToViewModel()
        {
            CreateMap<MovieModel, MovieViewModel>()
                .ForMember(s => s.ActorsIds, opt=> opt.ResolveUsing((s, d, i, context) => {
                    if (s.Actors != null)
                    {
                        return s.Actors.Select(x => x.Id);
                    }
                    else return new List<Guid>();
                }))
                .ForMember(s => s.GenresIds, opt => opt.ResolveUsing((s, d, i, context) => {
                    if (s.Genres != null)
                    {
                        return s.Genres.Select(x => x.Id);
                    }
                    else return new List<Guid>();
                }));
            CreateMap<ActorModel, EditActorViewModel>()
                .ForMember(d => d.BirthDate, opt => opt.ResolveUsing((s, d, i, context) => {
                    return s.BirthDate.ToString("yyyy-MM-dd");
                }));
            CreateMap<CommentModel, CommentViewModel>()
                .ForMember(d => d.MovieId, opt => opt.ResolveUsing((s, d, i, context) =>
                {
                    return s.Movie.Id;
                }))
                .ForMember(d => d.UserId, opt => opt.ResolveUsing((s, d, i, context) => {
                    return s.User.Id;
                }))
                .ForMember(d => d.ReplyTo, opt => opt.ResolveUsing((s, d, i, context) =>
                {
                    return s.Id;
                }));
        }
    }

    public class ViewModelToModel : Profile
    {
        public ViewModelToModel()
        {
            CreateMap<MovieViewModel, MovieModel>()
                .ForMember(d => d.Actors, opt => opt.ResolveUsing((s, d, i, context) => {
                    var actors = new List<ActorModel>();
                    if (s.ActorsIds != null)
                    {
                        foreach (var actorId in s.ActorsIds)
                        {
                            actors.Add(new ActorModel { Id = actorId });
                        }
                    }
                    return actors;
                }))
                .ForMember(d => d.Genres, opt => opt.ResolveUsing((s, d, i, context) => {
                    var genres = new List<GenreModel>();
                    if (s.GenresIds != null)
                    {
                        foreach (var genreId in s.GenresIds)
                        {
                            genres.Add(new GenreModel { Id = genreId });
                        }
                    }
                    return genres;
                }));
            CreateMap<EditActorViewModel, ActorModel>()
                .ForMember(d => d.BirthDate, opt => opt.ResolveUsing((s, d, i, context) => {
                    return DateTime.Parse(s.BirthDate);
                }));
            CreateMap<GenreViewModel, GenreModel>();
            CreateMap<CommentViewModel, CommentModel>()
                .ForMember(d => d.ReplyTo, opt => opt.ResolveUsing((s, d, i, context) =>
                {
                    return new CommentModel { Id = s.ReplyTo };
                }))
                .ForMember(d => d.Movie, opt => opt.ResolveUsing((s, d, i, context) => {
                    return new MovieModel { Id = s.MovieId };
                }))
                .ForMember(d => d.User, opt => opt.ResolveUsing((s, d, i, context) => {
                    return new User { Id = s.UserId };
                }));
            CreateMap<MovieVoteViewModel, GradeModel>();
        }
    }
}