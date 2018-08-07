namespace MovieCom.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActorDisplayNameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "DisplayName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "DisplayName");
        }
    }
}
