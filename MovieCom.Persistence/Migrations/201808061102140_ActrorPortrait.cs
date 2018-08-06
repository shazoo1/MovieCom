namespace MovieCom.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActrorPortrait : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "Portrait_Id", c => c.Guid());
            CreateIndex("dbo.Actors", "Portrait_Id");
            AddForeignKey("dbo.Actors", "Portrait_Id", "dbo.Media", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actors", "Portrait_Id", "dbo.Media");
            DropIndex("dbo.Actors", new[] { "Portrait_Id" });
            DropColumn("dbo.Actors", "Portrait_Id");
        }
    }
}
