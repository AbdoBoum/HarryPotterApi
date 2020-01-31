namespace HarryPotterApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Epees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Portee = c.Int(nullable: false),
                        Longueur = c.Int(nullable: false),
                        Nom = c.String(nullable: false),
                        Degats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        PositionY = c.Int(nullable: false),
                        PositionX = c.Int(nullable: false),
                        PointsDeVie = c.Int(nullable: false),
                        Epee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Epees", t => t.Epee_Id, cascadeDelete: true)
                .Index(t => t.Epee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Heroes", "Epee_Id", "dbo.Epees");
            DropIndex("dbo.Heroes", new[] { "Epee_Id" });
            DropTable("dbo.Heroes");
            DropTable("dbo.Epees");
        }
    }
}
