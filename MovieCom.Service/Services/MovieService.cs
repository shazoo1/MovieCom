﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieCom.Domain.Contracts;
using MovieCom.Domain.Models.Entities;
using MovieCom.Service.Interfaces;
using MovieCom.Service.Models;
using MovieCom.Service.Services.Base;

namespace MovieCom.Service.Services
{
    public class MovieService : BaseService<Movie>, IMovieService
    {
        public MovieService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }

        public void AddOrUpdate(MovieModel movie, IEnumerable<Guid> genres, IEnumerable<Guid> actors)
        {
            var movieRepo = _uow.Get<Movie>();
            var movieEntity = _mapper.Map<Movie>(movie);
            if (genres != null)
                movieEntity.Genres = _uow.Get<Genre>().GetAllWhere(x => genres.Contains(x.Id)).ToList();
            if (actors != null)
                movieEntity.Actors = _uow.Get<Actor>().GetAllWhere(x => genres.Contains(x.Id)).ToList();
            if (movie.Id == Guid.Empty)
            {
                movieEntity.CreatedAt = DateTime.Now;
            }
            movieEntity.LastModifiedAt = DateTime.Now;
            movieRepo.Update(movieEntity);
        }

        public MovieModel GetById(Guid id)
        {
            var movie = _uow.Get<Movie>().GetById(id);
            return _mapper.Map<MovieModel>(movie);
        }

        public IEnumerable<MovieModel> GetAll()
        {
            var movies = _uow.Get<Movie>().GetAll().ToList();
            return _mapper.Map<IEnumerable<MovieModel>>(movies);
        }

        public void Delete(Guid id)
        {
            _uow.Get<Movie>().Remove(id);
        }
    }
}
