using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Persistence;

namespace MovieCom.Domain.Stores
{
    public class RoleStore : RoleStore<Role, Guid, UserRole>
    {
        public RoleStore(MovieComDbContext context) : base(context.DbContext) { }
    }
}
