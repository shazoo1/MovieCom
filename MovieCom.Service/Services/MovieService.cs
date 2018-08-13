using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieCom.Domain.Contracts;
using MovieCom.Domain.Contracts.Repositories.Interfaces;
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

        public void AddOrUpdate(MovieModel movieModel)
        {
            var movieRepo = _uow.Get<Movie>();
            var movieEntity = movieRepo.GetById(movieModel.Id);
            bool isNew = movieEntity == null;
            if (isNew)
                movieEntity = new Movie();

            _mapper.Map<MovieModel, Movie>(movieModel, movieEntity);
            if (movieEntity.Poster != null)
            {
                movieEntity.Poster.LastModifiedAt = DateTime.Now;
            }
            else
            {
                movieEntity.Poster = new Media
                {
                    Id = Guid.NewGuid(),
                    Link = "",
                    CreatedAt = DateTime.Now,
                    Type = Common.Enums.MediaType.Poster,
                    LastModifiedAt = DateTime.Now
                };
            }
            if (movieEntity.Poster.Id == Guid.Empty)
            {
                movieEntity.Poster.Id = Guid.NewGuid();
            }
            var actorIds = movieModel.Actors.Select(x => x.Id);
            movieEntity.Actors = (ICollection<Actor>)_uow.Get<Actor>().GetByIds(actorIds);
            var genreIds = movieModel.Genres.Select(x => x.Id);
            movieEntity.Genres = (ICollection<Genre>)_uow.Get<Genre>().GetByIds(genreIds);

            if (isNew)
            {
                movieEntity.Id = Guid.NewGuid();
                movieEntity.CreatedAt = DateTime.Now;
                movieRepo.Add(movieEntity);
            }
            movieEntity.LastModifiedAt = DateTime.Now;
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

        public IEnumerable<MovieModel> GetTopRating(int topCount)
        {
            var movieRepo = (IMovieRepository)_uow.Get<Movie>();
            var movieEntities = movieRepo.GetTopByRating(topCount);
            return _mapper.Map<IEnumerable<MovieModel>>(movieEntities);
        }

        public void VoteForMovie(GradeModel gradeModel)
        {
            var gradeRepo = _uow.Get<Grade>();

            var gradeEntity = gradeRepo.GetAll()
                .Where(x => x.MovieId == gradeModel.MovieId && x.UserId == gradeModel.UserId)
                .FirstOrDefault();

            if (gradeEntity == null)
            {
                gradeEntity = new Grade
                {
                    CreatedAt = DateTime.Now,
                    Id = Guid.NewGuid()
                };
                _mapper.Map<GradeModel, Grade>(gradeModel, gradeEntity);
                gradeRepo.Add(gradeEntity);
            }
            else
            {
                _mapper.Map<GradeModel, Grade>(gradeModel, gradeEntity);
            }

            var movieToVoteFor = _uow.Get<Movie>().GetById(gradeModel.MovieId);
            var votesCount = movieToVoteFor.Grades.Count;
            var votesSum = movieToVoteFor.Grades.Select(x => x.Value).Sum();
            movieToVoteFor.Rating = votesSum / votesCount;
            _uow.SaveChanges();
        }
    }
}
