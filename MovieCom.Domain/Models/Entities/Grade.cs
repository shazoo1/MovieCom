using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Entities.Identity;

namespace MovieCom.Domain.Models.Entities
{
    public class Grade : BaseEntity
    {
        public int Value { get; set; }
        public virtual User User { get; set; }
    }
}
