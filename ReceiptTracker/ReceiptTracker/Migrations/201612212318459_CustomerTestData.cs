namespace ReceiptTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTestData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceiptModels", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReceiptModels", "UserId");
            AddForeignKey("dbo.ReceiptModels", "UserId", "dbo.UserModels", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiptModels", "UserId", "dbo.UserModels");
            DropIndex("dbo.ReceiptModels", new[] { "UserId" });
            DropColumn("dbo.ReceiptModels", "UserId");
        }
    }
}
