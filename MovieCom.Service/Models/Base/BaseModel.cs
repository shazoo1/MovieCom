using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCom.Service.Models.Base
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
    }
}
