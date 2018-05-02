namespace Tapas.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.rest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        s1 = c.String(),
                        s2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(),
                        Country = c.String(),
                        Zipcode = c.String(),
                        Phone = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(maxLength: 200),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.rest", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Restaurant_Id", "dbo.rest");
            DropIndex("dbo.Reviews", new[] { "Restaurant_Id" });
            DropTable("dbo.Reviews");
            DropTable("dbo.rest");
        }
    }
}
