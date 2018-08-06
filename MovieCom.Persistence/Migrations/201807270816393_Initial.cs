namespace MovieCom.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Bio = c.String(nullable: false, maxLength: 1000),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Slogan = c.String(maxLength: 150),
                        Description = c.String(nullable: false, maxLength: 500),
                        Year = c.Int(nullable: false),
                        Imdb = c.Decimal(nullable: false, precision: 3, scale: 1),
                        Rating = c.Decimal(nullable: false, precision: 3, scale: 1),
                        Poster_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Media", t => t.Poster_Id)
                .Index(t => t.Poster_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(nullable: false, maxLength: 500),
                        CreatedAt = c.DateTime(nullable: false),
                        LastModifiedAt = c.DateTime(),
                        Movie_Id = c.Guid(),
                        ReplyTo_Id = c.Guid(),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .ForeignKey("dbo.Comments", t => t.ReplyTo_Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.ReplyTo_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.Int(nullable: false),
                        User_Id = c.Guid(nullable: false),
                        Movie_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Link = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Movie_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenreMovies",
                c => new
                    {
                        Genre_Id = c.Guid(nullable: false),
                        Movie_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Movie_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.ActorMovies",
                c => new
                    {
                        Actor_Id = c.Guid(nullable: false),
                        Movie_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Actor_Id, t.Movie_Id })
                .ForeignKey("dbo.Actors", t => t.Actor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Actor_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.ActorMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.ActorMovies", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.Movies", "Poster_Id", "dbo.Media");
            DropForeignKey("dbo.Media", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Grades", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Grades", "User_Id", "dbo.Users");
            DropForeignKey("dbo.GenreMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.GenreMovies", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "ReplyTo_Id", "dbo.Comments");
            DropForeignKey("dbo.Comments", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.ActorMovies", new[] { "Movie_Id" });
            DropIndex("dbo.ActorMovies", new[] { "Actor_Id" });
            DropIndex("dbo.GenreMovies", new[] { "Movie_Id" });
            DropIndex("dbo.GenreMovies", new[] { "Genre_Id" });
            DropIndex("dbo.Media", new[] { "Movie_Id" });
            DropIndex("dbo.Grades", new[] { "Movie_Id" });
            DropIndex("dbo.Grades", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "ReplyTo_Id" });
            DropIndex("dbo.Comments", new[] { "Movie_Id" });
            DropIndex("dbo.Movies", new[] { "Poster_Id" });
            DropTable("dbo.ActorMovies");
            DropTable("dbo.GenreMovies");
            DropTable("dbo.Roles");
            DropTable("dbo.Media");
            DropTable("dbo.Grades");
            DropTable("dbo.Genres");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
        }
    }
}
