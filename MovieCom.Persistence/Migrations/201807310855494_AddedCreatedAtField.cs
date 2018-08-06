namespace MovieCom.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCreatedAtField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genres", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Grades", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Media", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Media", "CreatedAt");
            DropColumn("dbo.Grades", "CreatedAt");
            DropColumn("dbo.Genres", "CreatedAt");
            DropColumn("dbo.Movies", "CreatedAt");
            DropColumn("dbo.Actors", "CreatedAt");
        }
    }
}
