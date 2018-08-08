using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieCom.Service.Models;

namespace MovieCom.Web.Models.Movie
{
    public class GenresListViewModel
    {
        public IEnumerable<GenreModel> Genres { get; set; }
        public GenreViewModel Genre { get; set; }
    }
}