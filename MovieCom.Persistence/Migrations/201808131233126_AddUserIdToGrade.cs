namespace MovieCom.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToGrade : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Grades", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Grades", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Grades", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Grades", name: "UserId", newName: "User_Id");
        }
    }
}
