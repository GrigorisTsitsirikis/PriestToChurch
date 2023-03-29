namespace MyFirstMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriestModelChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Priests", "DatePicker", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Priests", "DatePicker");
        }
    }
}
