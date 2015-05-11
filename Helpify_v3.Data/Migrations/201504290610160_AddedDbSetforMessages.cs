namespace Helpify_v3.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDbSetforMessages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.MessageProjectLookups", "ProjectId");
            AddForeignKey("dbo.MessageProjectLookups", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageProjectLookups", "ProjectId", "dbo.Projects");
            DropIndex("dbo.MessageProjectLookups", new[] { "ProjectId" });
            DropColumn("dbo.Messages", "ProjectId");
        }
    }
}
