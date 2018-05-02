namespace Tapas.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeReviewsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reviews", "Modified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "Modified");
            DropColumn("dbo.Reviews", "Created");
        }
    }
}
