using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Entities.Identity;

namespace MovieCom.Domain.Models.Entities
{
    public class Grade : BaseEntity
    {
        public int Value { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
