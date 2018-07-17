using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Entities.Identity;
using MovieCom.Service.Models.Base;

namespace MovieCom.Service.Models
{
    public class CommentModel : BaseModel
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public MovieModel Movie { get; set; }
        public User User { get; set; }
        public CommentModel ReplyTo { get; set; }
        public ICollection<CommentModel> Replies { get; set; }
    }
}
