using MovieCom.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCom.Web.Models.Actors
{
    public class EditActorViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Отчетво (второе имя)")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [Display(Name="Отображаемое имя")]
        public string DisplayName { get; set; }
        [Display(Name = "Биография")]
        public string Bio { get; set; }
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string BirthDate { get; set; }
        [Display(Name = "Фото")]
        public string PortraitLink { get; set; }
    }
}