using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Service.Models.Base;

namespace MovieCom.Service.Models
{
    public class GenreModel : BaseModel
    {
        public string Name { get; set; }
        public ICollection<MovieModel> Movies { get; set; }
    }
}
