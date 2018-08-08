using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCom.Web.Models.Movie
{
    public class GenreViewModel
    {
        [Required]
        [Display(Name = "Жанр")]
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}