using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Common.Enums;
using MovieCom.Service.Models.Base;

namespace MovieCom.Service.Models
{
    public class MediaModel : BaseModel
    {
        public string Link { get; set; }
        public MediaType Type { get; set; }
    }
}
