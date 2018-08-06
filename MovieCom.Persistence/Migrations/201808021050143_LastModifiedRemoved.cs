namespace MovieCom.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastModifiedRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Actors", "LastModifiedAt");
            DropColumn("dbo.Movies", "LastModifiedAt");
            DropColumn("dbo.Genres", "LastModifiedAt");
            DropColumn("dbo.Grades", "LastModifiedAt");
            DropColumn("dbo.Media", "LastModifiedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Media", "LastModifiedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Grades", "LastModifiedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genres", "LastModifiedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "LastModifiedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Actors", "LastModifiedAt", c => c.DateTime(nullable: false));
        }
    }
}
