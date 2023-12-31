﻿namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormationColAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Formations", "Description", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Formations", "ImgUrl", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Formations", "ImgUrl");
            DropColumn("dbo.Formations", "Description");
        }
    }
}
