using System;
using System.Data.Entity;
using MovieCom.Domain.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieCom.Domain.Models.Entities;
using MovieCom.Persistence.Mapping;
using Persistence.Mapping;
using MovieCom.Domain.Contracts;

namespace MovieCom.Persistence
{
    public class MovieComDbContext : IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>, IMovieComDbContext
    {
        public MovieComDbContext() : base("MovieComDbContext") {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieComDbContext, Configuration>());
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbContext DbContext { get => this; }

        public static MovieComDbContext Create()
        {
            return new MovieComDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ActorMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new GenreMap());
            modelBuilder.Configurations.Add(new GradeMap());
            modelBuilder.Configurations.Add(new MediaMap());
            modelBuilder.Configurations.Add(new MovieMap());

            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
