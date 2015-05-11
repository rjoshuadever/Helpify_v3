namespace Helpify_v3.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedProjectIdFkfromMessage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "ProjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "ProjectId", c => c.Int(nullable: false));
        }
    }
}
