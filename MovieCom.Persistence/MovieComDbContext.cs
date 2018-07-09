using System;
using System.Data.Entity;
using MovieCom.Domain.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieCom.Domain.Models.Entities;

namespace MovieCom.Persistence
{
    public class MovieComDbContext : IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public MovieComDbContext() : base("MovieComDbContext") { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbContext DbContext { get => this; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
