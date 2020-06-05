namespace MyFirstMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToChurchandPriest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Churches", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Priests", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Priests", "Name", c => c.String());
            AlterColumn("dbo.Churches", "Name", c => c.String());
        }
    }
}
