using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCom.Domain.Models.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Slogan { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal Imdb { get; set; }
        public decimal Rating { get; set; }
        public double Votes { get; set; }
        public virtual Media Poster { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Media> Media { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}