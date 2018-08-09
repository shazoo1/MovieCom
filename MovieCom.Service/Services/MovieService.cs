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
            var repo = _uow.Get<Movie>();
            var moentity = repo.GetById(movie.Id);
            moentity = _mapper.Map<Movie>(movie);
            moentity.Poster = new Media
            {
                Id = Guid.NewGuid(),
                Link = "lkhbflsdj sf",
                Type = Common.Enums.MediaType.Poster,
                CreatedAt = DateTime.Now,
                LastModifiedAt = DateTime.Now
            };

            repo.Update(moentity);
            _uow.SaveChanges();

            return;
            //var movieRepo = _uow.Get<Movie>();
            //var movieEntity = _mapper.Map<Movie>(movie);
            var movieEntity = _uow.Get<Movie>().GetById(movie.Id);
            _mapper.Map(movie, movieEntity);

            var mediaRepo = _uow.Get<Media>();
            

            var actorIds = movie.Actors.Select(x => x.Id);
            var genreIds = movie.Genres.Select(x => x.Id);

            //movieEntity.Actors = _uow.Get<Actor>().GetByIds(actorIds).ToList();
            //movieEntity.Genres = _uow.Get<Genre>().GetByIds(genreIds).ToList();

            if (movieEntity.Poster != null)
            {
                movieEntity.Poster.Id = Guid.NewGuid();
                movieEntity.Poster.CreatedAt = DateTime.Now;
                //mediaRepo.Add(movieEntity.Poster);
            }

            if (movie.Id == Guid.Empty)
            {
                movieEntity.CreatedAt = DateTime.Now;
                movieEntity.Id = Guid.NewGuid();
                //movieRepo.Add(movieEntity);
            }
            else
            {
                movieEntity.LastModifiedAt = DateTime.Now;
                //movieRepo.Update(movieEntity);
            }
            _uow.SaveChanges();
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
