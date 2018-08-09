using System;
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

        public void AddOrUpdate(MovieModel movie)
        {
            var movieRepo = _uow.Get<Movie>();
            var movieEntity = _mapper.Map<Movie>(movie);
            var actorIds = movie.Actors.Select(x => x.Id);
            var genreIds = movie.Genres.Select(x => x.Id);

            movieEntity.Actors = (ICollection<Actor>)_uow.Get<Actor>().GetByIds(actorIds);
            movieEntity.Genres = (ICollection<Genre>)_uow.Get<Genre>().GetByIds(genreIds);

            if (movieEntity.Poster != null)
            {
                movieEntity.Poster.Id = Guid.NewGuid();
                movieEntity.Poster.CreatedAt = DateTime.Now;
            }

            if (movie.Id == Guid.Empty)
            {
                movieEntity.CreatedAt = DateTime.Now;
                movieEntity.Id = Guid.NewGuid();
                movieRepo.Add(movieEntity);
            }
            else
            {
                movieEntity.LastModifiedAt = DateTime.Now;
                movieRepo.Update(movieEntity);
            }
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
