namespace MyFirstMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriestModelChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Priests", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Priests", "PhoneNumber", c => c.String(maxLength: 30));
            AddColumn("dbo.Priests", "Church_Id", c => c.Int());
            CreateIndex("dbo.Priests", "Church_Id");
            AddForeignKey("dbo.Priests", "Church_Id", "dbo.Churches", "Id");

            Sql("INSERT INTO Priests (LastName,Name,PhoneNumber) VALUES ('ΤΣΙΤΣΙΡΙΚΗΣ','ΘΕΜΙΣΤΟΚΛΗΣ','6944612999')");




        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Priests", "Church_Id", "dbo.Churches");
            DropIndex("dbo.Priests", new[] { "Church_Id" });
            DropColumn("dbo.Priests", "Church_Id");
            DropColumn("dbo.Priests", "PhoneNumber");
            DropColumn("dbo.Priests", "LastName");
        }
    }
}
