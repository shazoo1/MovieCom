using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Persistence
{
    public class MovieComDbContext : IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public MovieComDbContext() : base("MovieComDbContext") { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Movie> movies { get; set; }

        public DbContext DbContext { get => this; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
