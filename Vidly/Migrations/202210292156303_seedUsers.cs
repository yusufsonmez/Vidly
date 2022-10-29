namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
    VALUES (3,'yusuf@gmail.com',1, 123456, 123456, NULL, 0, 0, NULL, 1, 0, 'admin2@vidly.com') 
"
        );
        }
        
        public override void Down()
        {
        }
    }
}
