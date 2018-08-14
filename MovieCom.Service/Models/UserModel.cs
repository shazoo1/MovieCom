using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Service.Models.Base;
using Newtonsoft.Json;

namespace MovieCom.Service.Models
{
    public class UserModel : BaseModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public ICollection<CommentModel> Comments { get; set; }
    }
}
