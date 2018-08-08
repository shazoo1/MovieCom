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
            CreateMap<MovieModel, MovieViewModel>()
                .ForMember(s => s.Actors, opt=> opt.ResolveUsing((s, d, i, context) => {
                    if (s.Actors != null)
                    {
                        return s.Actors.Select(x => x.Id);
                    }
                    else return new List<Guid>();
                }))
                .ForMember(s => s.Genres, opt => opt.ResolveUsing((s, d, i, context) => {
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
        }
    }

    public class ViewModelToModel : Profile
    {
        public ViewModelToModel()
        {
            CreateMap<MovieViewModel, MovieModel>()
                .ForMember(d => d.Actors, opt => opt.ResolveUsing((s, d, i, context) => {
                    var actors = new List<ActorModel>();
                    if (s.Actors != null)
                    {
                        foreach (var actorId in s.Actors)
                        {
                            actors.Add(new ActorModel { Id = actorId });
                        }
                    }
                    return actors;
                }))
                .ForMember(d => d.Genres, opt => opt.ResolveUsing((s, d, i, context) => {
                    var genres = new List<GenreModel>();
                    if (s.Genres != null)
                    {
                        foreach (var genreId in s.Genres)
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
        }
    }
}