namespace MyFirstMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePriestsAndChurches : DbMigration
    {
        public override void Up()
        {
            //initial Churches 
            Sql("INSERT INTO Churches (Name) VALUES (N'ΑΓΙΑ ΠΑΡΑΣΚΕΥΗ')");
            Sql("INSERT INTO Churches (Name) VALUES (N'ΑΓΙΟΣ ΔΗΜΗΤΡΙΟΣ')");

            //initial Priests
            Sql("INSERT INTO Priests (Name) VALUES (N'Π.ΘΕΜΙΣΤΟΚΛΗΣ')");
            Sql("INSERT INTO Priests (Name) VALUES (N'Π.ΘΩΜΑΣ')");
            Sql("INSERT INTO Priests (Name) VALUES (N'Π.ΓΕΩΡΓΙΟΣ')");



        }

        public override void Down()
        {
        }
    }
}
