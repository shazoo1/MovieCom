﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Entities.Identity;

namespace MovieCom.Domain.Models.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public virtual Movie Movie { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Comment ReplyTo { get; set; }
        public virtual ICollection<Comment> Replies { get; set; }
    }
}
