namespace ManagerHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangemodelBookingandsetrelatedmodelservicevsreceipt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropIndex("dbo.Bookings", new[] { "UserId" });
            RenameColumn(table: "dbo.Bookings", name: "UserId", newName: "User_UserId");
            AddColumn("dbo.Bookings", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "Receipt_ReceiptId", c => c.Int());
            AlterColumn("dbo.Bookings", "User_UserId", c => c.Int());
            CreateIndex("dbo.Bookings", "User_UserId");
            CreateIndex("dbo.Services", "Receipt_ReceiptId");
            AddForeignKey("dbo.Services", "Receipt_ReceiptId", "dbo.Receipts", "ReceiptId");
            AddForeignKey("dbo.Bookings", "User_UserId", "dbo.Users", "UserId");
            DropColumn("dbo.Bookings", "IsCheckedIn");
            DropColumn("dbo.Bookings", "IsCheckedOut");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "IsCheckedOut", c => c.Boolean(nullable: false));
            AddColumn("dbo.Bookings", "IsCheckedIn", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Bookings", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Services", "Receipt_ReceiptId", "dbo.Receipts");
            DropIndex("dbo.Services", new[] { "Receipt_ReceiptId" });
            DropIndex("dbo.Bookings", new[] { "User_UserId" });
            AlterColumn("dbo.Bookings", "User_UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Services", "Receipt_ReceiptId");
            DropColumn("dbo.Bookings", "Type");
            DropColumn("dbo.Bookings", "Status");
            RenameColumn(table: "dbo.Bookings", name: "User_UserId", newName: "UserId");
            CreateIndex("dbo.Bookings", "UserId");
            AddForeignKey("dbo.Bookings", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
