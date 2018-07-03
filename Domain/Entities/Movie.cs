using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Slogan { get; set; }
        public string Description { get; set; }
        public string PosterLink { get; set; }
        public int Year { get; set; }
        public float Imdb { get; set; }
        public float Rating { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<Media> Media { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Grade> Grades { get; set; }
    }
}