namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdates : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId, Birthdate) VALUES ('Aslı Yılmaz', 1, 1, 2000/01/01)");
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId, Birthdate) VALUES ('Melih Yıldız', 0, 2, 1998/01/01)");

        }

        public override void Down()
        {
        }
    }
}
