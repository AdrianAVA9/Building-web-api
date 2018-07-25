namespace ExpenseTracker.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 100),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 250),
                        ExpenseGroupStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseGroupStatus", t => t.ExpenseGroupStatusId)
                .Index(t => t.ExpenseGroupStatusId);
            
            CreateTable(
                "dbo.ExpenseGroupStatus",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
                        date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 0),
                        ExpenseGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseGroups", t => t.ExpenseGroupId, cascadeDelete: true)
                .Index(t => t.ExpenseGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "ExpenseGroupId", "dbo.ExpenseGroups");
            DropForeignKey("dbo.ExpenseGroups", "ExpenseGroupStatusId", "dbo.ExpenseGroupStatus");
            DropIndex("dbo.Expenses", new[] { "ExpenseGroupId" });
            DropIndex("dbo.ExpenseGroups", new[] { "ExpenseGroupStatusId" });
            DropTable("dbo.Expenses");
            DropTable("dbo.ExpenseGroupStatus");
            DropTable("dbo.ExpenseGroups");
        }
    }
}
