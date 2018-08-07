using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MovieCom.Common.Enums;
using MovieCom.Service.Interfaces;
using MovieCom.Service.Models;
using MovieCom.Service.Services;
using MovieCom.Web.Controllers.Base;
using MovieCom.Web.Models.Movie;
using MovieCom.Web.Helpers.Interfaces;

namespace MovieCom.Web.Controllers
{
    public class MovieController : BaseController
    {
        

        public MovieController(IServiceHost serviceHost, IMapper mapper) : base(mapper, serviceHost)
        {
        }

        // GET: Movie
        public ActionResult Index()
        {
            var model = new MoviesListViewModel();
            var movieService = _serviceHost.GetService<MovieService>();

            model.Movies = movieService.GetAll();
            return View(model);
        }
        
        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult Edit(Guid? id)
        {
            AddMovieViewModel model;
            var movieService = _serviceHost.GetService<MovieService>();
            var genreService = _serviceHost.GetService<GenreService>();
            var actorService = _serviceHost.GetService<ActorService>();

            if (id == null || id != Guid.Empty)
            {
                model = new AddMovieViewModel();
            }
            else
            {
                var movie = movieService.GetById(id.GetValueOrDefault());
                model = _mapper.Map<AddMovieViewModel>(movie);
            }
            model.Genres = genreService.GetAll();
            model.Actors = actorService.GetAll();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult Edit(AddMovieViewModel model)
        {
            var movie = _mapper.Map<MovieModel>(model);
            var movieService = _serviceHost.GetService<MovieService>();
            var genreService = _serviceHost.GetService<GenreService>();
            var actorService = _serviceHost.GetService<ActorService>();

            movie.Poster = new MediaModel { Link = model.PosterLink, Type = MediaType.Poster };
            if (model.SelectedGenres != null)
                movie.Genres = genreService.GetByIds(model.SelectedGenres);
            if (model.SelectedActors != null)
                movie.Actors = actorService.GetByIds(model.SelectedActors);
            movieService.AddOrUpdate(movie, model.SelectedGenres, model.SelectedActors);
            return RedirectToAction("Index", "Movie");
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult Delete(Guid id)
        {
            var movieService = _serviceHost.GetService<MovieService>();

            movieService.Delete(id);
            return RedirectToAction("Index", "Movie");
        }
    }
}