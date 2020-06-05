namespace MyFirstMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePriestsAndChurches : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Churches (Name) VALUES ('ΑΓΙΑ ΠΑΡΑΣΚΕΥΗ')");
            Sql("INSERT INTO Churches (Name) VALUES ('ΑΓΙΟΣ ΔΗΜΗΤΡΙΟΣ')");


            Sql("INSERT INTO Priests (Name) VALUES ('Π.ΘΕΜΙΣΤΟΚΛΗΣ')");
            Sql("INSERT INTO Priests (Name) VALUES ('Π.ΚΑΛΛΙΝΙΚΟΣ')");
            Sql("INSERT INTO Priests (Name) VALUES ('Π.ΘΩΜΑΣ')");
            Sql("INSERT INTO Priests (Name) VALUES ('Π.ΓΕΩΡΓΙΟΣ')");

        }
        
        public override void Down()
        {
        }
    }
}
