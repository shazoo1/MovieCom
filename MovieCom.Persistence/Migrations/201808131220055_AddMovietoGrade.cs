namespace MovieCom.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovietoGrade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grades", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Grades", new[] { "Movie_Id" });
            RenameColumn(table: "dbo.Grades", name: "Movie_Id", newName: "MovieId");
            AlterColumn("dbo.Grades", "MovieId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Grades", "MovieId");
            AddForeignKey("dbo.Grades", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "MovieId", "dbo.Movies");
            DropIndex("dbo.Grades", new[] { "MovieId" });
            AlterColumn("dbo.Grades", "MovieId", c => c.Guid());
            RenameColumn(table: "dbo.Grades", name: "MovieId", newName: "Movie_Id");
            CreateIndex("dbo.Grades", "Movie_Id");
            AddForeignKey("dbo.Grades", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
