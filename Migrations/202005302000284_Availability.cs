namespace MyFirstMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Availability : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Priests", "Available", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Priests", "Available");
        }
    }
}
