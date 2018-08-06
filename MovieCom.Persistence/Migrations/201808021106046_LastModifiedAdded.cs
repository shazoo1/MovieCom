namespace MovieCom.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastModifiedAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "LastModifiedAt", c => c.DateTime());
            AddColumn("dbo.Movies", "LastModifiedAt", c => c.DateTime());
            AddColumn("dbo.Genres", "LastModifiedAt", c => c.DateTime());
            AddColumn("dbo.Grades", "LastModifiedAt", c => c.DateTime());
            AddColumn("dbo.Media", "LastModifiedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Media", "LastModifiedAt");
            DropColumn("dbo.Grades", "LastModifiedAt");
            DropColumn("dbo.Genres", "LastModifiedAt");
            DropColumn("dbo.Movies", "LastModifiedAt");
            DropColumn("dbo.Actors", "LastModifiedAt");
        }
    }
}
