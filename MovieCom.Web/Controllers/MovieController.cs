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

namespace MovieCom.Web.Controllers
{
    public class MovieController : BaseController
    {
        
        IGenreService _genreService;
        IActorService _actorService;
        IMovieService _movieService;

        public MovieController(IGenreService genreService, IActorService actorService,
            IMovieService movieService, IMapper mapper) : base(mapper)
        {
            _genreService = genreService;
            _actorService = actorService;
            _movieService = movieService;
        }

        // GET: Movie
        public ActionResult Index()
        {
            var model = new MoviesListViewModel();
            model.Movies = _movieService.GetAll();
            return View(model);
        }
        
        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult Edit(Guid? id)
        {
            AddMovieViewModel model;
            if (id == null)
            {
                model = new AddMovieViewModel();
            }
            else
            {
                var movie = _movieService.GetById(id.GetValueOrDefault());
                model = _mapper.Map<AddMovieViewModel>(movie);
            }
            model.Genres = _genreService.GetAll();
            model.Actors = _actorService.GetAll();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult Edit(AddMovieViewModel model)
        {
            var movie = _mapper.Map<MovieModel>(model);
            movie.Poster = new MediaModel { Link = model.PosterLink, Type = MediaType.Poster };
            if (model.SelectedGenres != null)
                movie.Genres = _genreService.GetByIds(model.SelectedGenres);
            if (model.SelectedActors != null)
                movie.Actors = _actorService.GetByIds(model.SelectedActors);
            _movieService.AddOrUpdate(movie, model.SelectedGenres, model.SelectedActors);
            return RedirectToAction("Index", "Movie");
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult Delete(Guid id)
        {
            _movieService.Delete(id);
            return RedirectToAction("Index", "Movie");
        }
    }
}