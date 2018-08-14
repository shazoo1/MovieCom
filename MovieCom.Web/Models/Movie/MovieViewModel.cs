﻿using MovieCom.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCom.Web.Models.Movie
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Название")]
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

        [Display(Name = "В ролях")]
        public IEnumerable<Guid> ActorsIds { get; set; }
        [Display(Name = "В ролях")]

        public IEnumerable<ActorModel> Actors { get; set; }


        [Display(Name = "Жанр")]
        public IEnumerable<Guid> GenresIds { get; set; }
        [Display(Name = "Жанр")]
        public IEnumerable<GenreModel> Genres { get; set; }

        [Display(Name = "Оценка")]
        public int Grade { get; set; }

        public IEnumerable<MediaModel> Media { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }
    }
}