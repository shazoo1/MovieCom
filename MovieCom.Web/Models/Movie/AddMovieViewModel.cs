using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieCom.Service.Models;

namespace MovieCom.Web.Models.Movie
{
    public class AddMovieViewModel
    {
        
        [Display(Name ="Название")]
        [Required(ErrorMessage = "Введите название фильма.")]
        public string Title { get; set; }
        [Display(Name = "Слоган")]
        public string Slogan { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Необходимо описание фильма.")]
        public string Description { get; set; }
        [Display(Name = "Год выпуска")]
        [Required(ErrorMessage = "Введите год выпуска фильма.")]
        public int Year { get; set; }
        [Display(Name = "Рейтинг IMDB")]
        public decimal Imdb { get; set; }
        [Display(Name = "Ретинг пользователей MovieCom")]
        public decimal Rating { get; set; }
        public string PosterLink { get; set; }
        public ICollection<ActorModel> Actors { get; set; }
        public ICollection<MediaModel> Media { get; set; }
        public ICollection<GenreModel> Genres { get; set; }
    }
}