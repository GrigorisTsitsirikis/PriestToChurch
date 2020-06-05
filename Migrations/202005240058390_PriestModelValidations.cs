namespace MyFirstMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriestModelValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Priests", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Priests", "Name", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Priests", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Priests", "LastName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
