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
        public Guid Id { get; set; }   
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
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal Imdb { get; set; }
        [Display(Name = "Ретинг пользователей MovieCom")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal Rating { get; set; }
        [Display(Name = "Ссылка на постер")]
        public string PosterLink { get; set; }
        public IEnumerable<Guid> SelectedActors { get; set; }
        [Display(Name = "В ролях")]
        public IEnumerable<ActorModel> Actors { get; set; }
        public IEnumerable<MediaModel> Media { get; set; }
        public IEnumerable<Guid> SelectedGenres { get; set; }
        [Display(Name = "Жанр")]
        public IEnumerable<GenreModel> Genres { get; set; }
    }
}