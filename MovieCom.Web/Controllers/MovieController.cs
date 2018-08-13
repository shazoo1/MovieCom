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
using System.IO;
using Microsoft.AspNet.Identity;
using MovieCom.Domain.Entities.Identity;

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
            model.TopTenRating = movieService.GetTopRating(10);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult Edit(Guid? id)
        {
            AddMovieViewModel model = new AddMovieViewModel();
            var movieService = _serviceHost.GetService<MovieService>();
            var genreService = _serviceHost.GetService<GenreService>();
            var actorService = _serviceHost.GetService<ActorService>();

            if (id != null && id != Guid.Empty)
            {
                var movie = movieService.GetById(id.GetValueOrDefault());
                model.Movie = _mapper.Map<MovieViewModel>(movie);
            }
            else
            {
                model.Movie = new MovieViewModel();
            }
            model.AllGenres = genreService.GetAll();
            model.AllActors = actorService.GetAll();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult Edit(AddMovieViewModel model)
        {
            var movieService = _serviceHost.GetService<MovieService>();
            var movie = _mapper.Map<MovieViewModel, MovieModel>(model.Movie);
            if (!string.IsNullOrEmpty(model.Movie.PosterLink))
            {
                movie.Poster = new MediaModel { Link = model.Movie.PosterLink, Type = MediaType.Poster };
            }
            movieService.AddOrUpdate(movie);

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

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult UploadPoster()
        {
            string path = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    if (file != null && file.ContentLength > 0)
                    {
                        var originalDirectory = new DirectoryInfo(string.Format("{0}Uploads\\", Server.MapPath("~/")));
                        var fileExtension = Path.GetExtension(file.FileName);
                        var randomFileName = Path.GetRandomFileName();
                        var pathString = originalDirectory.ToString();
                        bool exists = System.IO.Directory.Exists(pathString);
                        if (!exists)
                            System.IO.Directory.CreateDirectory(pathString);
                        path = string.Format("{0}{1}", pathString, randomFileName + fileExtension);
                        file.SaveAs(path);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return Json(new { Message = path });
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult Genres()
        {
            var model = new GenresListViewModel();
            var genresService = _serviceHost.GetService<IGenreService>();
            model.Genres = genresService.GetAll();
            model.Genre = new GenreViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public ActionResult EditGenre(GenreViewModel genre)
        {
            var genreService = _serviceHost.GetService<IGenreService>();
            genreService.AddOrUpdate(_mapper.Map<GenreModel>(genre));
            return RedirectToAction("Genres", "Movie");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(Guid movieId)
        {
            MovieViewModel model = new MovieViewModel();
            var movieService = _serviceHost.GetService<IMovieService>();

            if (movieId != Guid.Empty)
            {
                var movie = movieService.GetById(movieId);
                model = _mapper.Map<MovieViewModel>(movie);
            }
            model.Comments = model.Comments.OrderBy(x => x.CreatedAt);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(CommentViewModel commentViewModel)
        {
            var commentService = _serviceHost.GetService<ICommentService>();
            var commentModel = _mapper.Map<CommentModel>(commentViewModel);
            commentModel.UserId = Guid.Parse(User.Identity.GetUserId());
            commentService.AddOrUpdate(commentModel);
            return RedirectToAction("Details", "Movie", new { movieId = commentViewModel.MovieId });
        }

        [HttpPost]
        [Authorize]
        public ActionResult Vote(MovieVoteViewModel model)
        {
            var grade = _mapper.Map<GradeModel>(model);
            grade.UserId = Guid.Parse(User.Identity.GetUserId());
            var movieService = _serviceHost.GetService<IMovieService>();
            movieService.VoteForMovie(grade);

            return RedirectToAction("Details", "Movie", new { movieId = model.MovieId });
        }
    }
}