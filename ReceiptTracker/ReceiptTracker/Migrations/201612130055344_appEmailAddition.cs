namespace ReceiptTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appEmailAddition : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserModels", "ReceiptUser_Id", "dbo.AspNetUsers");
            AddColumn("dbo.UserModels", "FirstName", c => c.String());
            AddColumn("dbo.UserModels", "LastName", c => c.String());
            AddForeignKey("dbo.UserModels", "ReceiptUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserModels", "ReceiptUser_Id", "dbo.AspNetUsers");
            DropColumn("dbo.UserModels", "LastName");
            DropColumn("dbo.UserModels", "FirstName");
            AddForeignKey("dbo.UserModels", "ReceiptUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
