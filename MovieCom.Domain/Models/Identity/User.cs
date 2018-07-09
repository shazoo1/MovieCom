using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Identity;
using Domain.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieCom.Domain.Entities.Identity
{
    public class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>
    {
        public ICollection<Comment> Comments { get; set; }
    }
}
