namespace MovieCom.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVotesCountForMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Votes", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Votes");
        }
    }
}
