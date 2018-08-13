using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieCom.Domain.Entities.Identity;

namespace MovieCom.Web.Models.Movie
{
    public class CommentViewModel
    {
        [Display(Name = "Комментарий")]
        [Required(ErrorMessage = "Введите текст комментария")]
        public string Text { get; set; }
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
        public Guid ReplyTo { get; set; }
    }
}