using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieCom.Service.Models;

namespace MovieCom.Web.Models.Movie
{
    public class AddMovieViewModel
    {
        public string Title { get; set; }
        public string Slogan { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal Imdb { get; set; }
        public decimal Rating { get; set; }
        public string PosterLink { get; set; }
        public ICollection<ActorModel> Actors { get; set; }
        public ICollection<MediaModel> Media { get; set; }
        public ICollection<GenreModel> Genres { get; set; }
    }
}