using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Entities.Identity;
using MovieCom.Service.Models.Base;

namespace MovieCom.Service.Models
{
    public class GradeModel : BaseModel
    {
        public int Value { get; set; }
        public User User { get; set; }
    }
}
