﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCom.Domain.Models.Entities
{
    public class Actor : BaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public Media Portrait { get; set; }
    }
}
