namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationsToMembershipTypeNameField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 255));

            Sql("INSERT INTO MembershipTypes (Id, SignUpFree, DurationInMonths, DiscountRate, Name) VALUES (1, 0, 0, 0, 'Pay As You Go')");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFree, DurationInMonths, DiscountRate, Name) VALUES (2, 30, 1, 10, 'Monthly')");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFree, DurationInMonths, DiscountRate, Name) VALUES (3, 90, 3, 15, 'Quarterly')");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFree, DurationInMonths, DiscountRate, Name) VALUES (4, 300, 12, 20, 'Annual')");

            Sql("INSERT INTO Customers (Id, Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES (1, 'Aslı Yılmaz', 1, 1)");
            Sql("INSERT INTO Customers (Id, Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES (2, 'Melih Yıldız', 0, 2)");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
        }
    }
}
