﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieCom.Persistence;
using MovieCom.Domain.Contracts;

namespace MovieCom.Domain.Stores
{
    public class RoleStore : RoleStore<Role, Guid, UserRole>
    {
        public RoleStore(IMovieComDbContext context) : base(context.DbContext) { }
    }
}
