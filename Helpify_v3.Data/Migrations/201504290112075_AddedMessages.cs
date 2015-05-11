namespace Helpify_v3.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMessages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageProjectLookups",
                c => new
                    {
                        MessageProjectLookupId = c.Int(nullable: false, identity: true),
                        MessageId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageProjectLookupId)
                .ForeignKey("dbo.Messages", t => t.MessageId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.MessageId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        SenderName = c.String(),
                        Location = c.String(),
                        MessageBody = c.String(),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageProjectLookups", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.MessageProjectLookups", "MessageId", "dbo.Messages");
            DropIndex("dbo.MessageProjectLookups", new[] { "ProjectId" });
            DropIndex("dbo.MessageProjectLookups", new[] { "MessageId" });
            DropTable("dbo.Messages");
            DropTable("dbo.MessageProjectLookups");
        }
    }
}
