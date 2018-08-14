using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Entities.Identity;
using MovieCom.Service.Models.Base;
using Newtonsoft.Json;

namespace MovieCom.Service.Models
{
    public class CommentModel : BaseModel
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        [JsonIgnore]
        public MovieModel Movie { get; set; }
        public UserModel User { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public CommentModel ReplyTo { get; set; }
        [JsonIgnore]
        public ICollection<CommentModel> Replies { get; set; }
    }
}
