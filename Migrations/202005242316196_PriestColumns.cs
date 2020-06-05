namespace MyFirstMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriestColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Priests", "IsEfimerios", c => c.Boolean(nullable: false));
            AddColumn("dbo.Priests", "IsEpoxiakos", c => c.Boolean(nullable: false));
            AddColumn("dbo.Priests", "IsIerokirikas", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Priests", "IsIerokirikas");
            DropColumn("dbo.Priests", "IsEpoxiakos");
            DropColumn("dbo.Priests", "IsEfimerios");
        }
    }
}
