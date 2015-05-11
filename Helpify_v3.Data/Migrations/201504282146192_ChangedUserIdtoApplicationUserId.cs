namespace Helpify_v3.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserIdtoApplicationUserId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserProjectLookups", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.UserProjectLookups", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            DropColumn("dbo.UserProjectLookups", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProjectLookups", "UserId", c => c.String());
            RenameIndex(table: "dbo.UserProjectLookups", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.UserProjectLookups", name: "ApplicationUserId", newName: "ApplicationUser_Id");
        }
    }
}
