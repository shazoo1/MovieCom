using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieCom.Domain.Contracts;
using MovieCom.Domain.Entities.Identity;

namespace MovieCom.Domain.Store
{
    public class RoleStore : RoleStore<Role, Guid, UserRole>
    {
        public RoleStore(IMovieComDbContext context)
            : base (context.DbContext) { }
    }
}
