namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestAnimateur = c.Int(nullable: false),
                        QuestFormation = c.Int(nullable: false),
                        QuestCondition = c.Int(nullable: false),
                        DateAjout = c.DateTime(nullable: false),
                        Description = c.String(),
                        FormationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Formations", t => t.FormationID, cascadeDelete: true)
                .Index(t => t.FormationID);
            
            CreateTable(
                "dbo.Formations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluations", "FormationID", "dbo.Formations");
            DropIndex("dbo.Evaluations", new[] { "FormationID" });
            DropTable("dbo.Formations");
            DropTable("dbo.Evaluations");
        }
    }
}
