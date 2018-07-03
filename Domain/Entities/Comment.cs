using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment : BaseEntity
    {
        public User User { get; set; }
        public string text { get; set; }
        public Movie Movie { get; set; }
        public int Order { get; set; }
    }
}
