using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCom.Service.Models;

namespace MovieCom.Web.Models.Movie
{
    public class AddMovieViewModel
    {
        public MovieViewModel Movie { get; set; }
        [Display(Name = "В ролях")]
        public IEnumerable<ActorModel> AllActors { get; set; }
        [Display(Name = "Жанр")]
        public IEnumerable<GenreModel> AllGenres { get; set; }
    }
}