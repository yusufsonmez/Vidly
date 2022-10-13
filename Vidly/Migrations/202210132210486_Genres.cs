﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Romance')");
        }

        public override void Down()
        {
        }
    }
}
