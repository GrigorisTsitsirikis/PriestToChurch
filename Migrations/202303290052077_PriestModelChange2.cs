namespace MyFirstMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriestModelChange2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Priests", "DatePicker", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Priests", "DatePicker", c => c.DateTime(nullable: false));
        }
    }
}
