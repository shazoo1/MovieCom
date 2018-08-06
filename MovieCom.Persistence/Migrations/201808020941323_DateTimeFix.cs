namespace MovieCom.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Movies", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Genres", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Grades", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Media", "CreatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Media", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Grades", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Genres", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Actors", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
