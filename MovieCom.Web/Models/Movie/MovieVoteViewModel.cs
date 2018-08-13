using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCom.Web.Models.Movie
{
    public class MovieVoteViewModel
    {
        public Guid MovieId { get; set; }
        public int Value { get; set; }
    }
}