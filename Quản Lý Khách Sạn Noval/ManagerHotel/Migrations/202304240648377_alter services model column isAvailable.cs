namespace ManagerHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterservicesmodelcolumnisAvailable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "IsAvailable", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "IsAvailable", c => c.Boolean(nullable: false));
        }
    }
}
