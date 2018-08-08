namespace MovieCom.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredFromActorsMiddleName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "MiddleName", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Actors", "MiddleName", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
