using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieCom.Service.Models;

namespace MovieCom.Web.Models.Movie
{
    public class MoviesListViewModel
    {
        public IEnumerable<MovieModel> Movies { get; set; }

        public IEnumerable<MovieModel> TopTenRating { get; set; }
    }
}