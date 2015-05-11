namespace Helpify_v3.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droppedvirtualprojectfrommessageprojectlookup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MessageProjectLookups", "ProjectId", "dbo.Projects");
            DropIndex("dbo.MessageProjectLookups", new[] { "ProjectId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.MessageProjectLookups", "ProjectId");
            AddForeignKey("dbo.MessageProjectLookups", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
    }
}
