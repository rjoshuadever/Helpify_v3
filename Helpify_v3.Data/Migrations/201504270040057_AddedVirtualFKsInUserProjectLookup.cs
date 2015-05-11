namespace Helpify_v3.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVirtualFKsInUserProjectLookup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProjectLookups", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserProjectLookups", "ProjectId");
            CreateIndex("dbo.UserProjectLookups", "ApplicationUser_Id");
            AddForeignKey("dbo.UserProjectLookups", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserProjectLookups", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProjectLookups", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.UserProjectLookups", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserProjectLookups", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserProjectLookups", new[] { "ProjectId" });
            DropColumn("dbo.UserProjectLookups", "ApplicationUser_Id");
        }
    }
}
