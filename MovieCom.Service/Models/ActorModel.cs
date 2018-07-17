using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Service.Models;
using MovieCom.Service.Models.Base;

namespace MovieCom.Service.Models
{
    public class ActorModel : BaseModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<MovieModel> Movies { get; set; }
    }
}
