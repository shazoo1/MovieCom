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
            var movie = _mapper.Map<MovieModel>(model.Movie);
            var movieService = _serviceHost.GetService<MovieService>();
            var genreService = _serviceHost.GetService<GenreService>();
            var actorService = _serviceHost.GetService<ActorService>();

            movie.Poster = new MediaModel { Link = model.Movie.PosterLink, Type = MediaType.Poster };
            
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
                        var originalDirectory = new DirectoryInfo(string.Format("{0}Uploads\\", Server.MapPath(@"\")));
                        var fileExtension = Path.GetExtension(file.FileName);
                        var fileName1 = Path.GetRandomFileName();
                        var pathString = originalDirectory.ToString();
                        bool exists = System.IO.Directory.Exists(pathString);
                        if (!exists)
                            System.IO.Directory.CreateDirectory(pathString);
                        path = string.Format("{0}{1}", pathString, fileName1 + fileExtension);
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
    }
}