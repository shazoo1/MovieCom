using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Models.Entities;
using MovieCom.Service.Models.Base;

namespace MovieCom.Service.Models
{
    public class MovieModel : BaseModel
    {
        public string Title { get; set; }
        public string Slogan { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal Imdb { get; set; }
        public decimal Rating { get; set; }
        public MediaModel Poster { get; set; }
        public IEnumerable<ActorModel> Actors { get; set; }
        public IEnumerable<MediaModel> Media { get; set; }
        public IEnumerable<GenreModel> Genres { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }
        public IEnumerable<GradeModel> Grades { get; set; }
        public string GenresString { get; set; }
        public double Votes { get; set; }
    }
}