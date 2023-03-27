namespace MyFirstMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChurchTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Churches", "IsBasic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Churches", "IsOreini", c => c.Boolean(nullable: false));
            AddColumn("dbo.Churches", "IsPanigirizousa", c => c.Boolean(nullable: false));
            AddColumn("dbo.Churches", "IsIeraMoni", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Churches", "IsIeraMoni");
            DropColumn("dbo.Churches", "IsPanigirizousa");
            DropColumn("dbo.Churches", "IsOreini");
            DropColumn("dbo.Churches", "IsBasic");
        }
    }
}
