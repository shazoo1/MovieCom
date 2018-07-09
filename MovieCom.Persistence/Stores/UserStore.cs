using System;
using MovieCom.Domain.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieCom.Persistence;

namespace MovieCom.Domain.Stores
{
    public class UserStore : UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public UserStore(MovieComDbContext context) : base(context.DbContext) { }
    }
}
