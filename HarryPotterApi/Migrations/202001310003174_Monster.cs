namespace HarryPotterApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Monster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gourdins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Poid = c.Int(nullable: false),
                        Nom = c.String(nullable: false),
                        Degats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Monsters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Niveau = c.Int(nullable: false),
                        Nom = c.String(nullable: false),
                        Avatar = c.String(),
                        PositionY = c.Int(nullable: false),
                        PositionX = c.Int(nullable: false),
                        PointsDeVie = c.Int(nullable: false),
                        Gourdin_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gourdins", t => t.Gourdin_Id, cascadeDelete: true)
                .Index(t => t.Gourdin_Id);
            
            AddColumn("dbo.Heroes", "Avatar", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Monsters", "Gourdin_Id", "dbo.Gourdins");
            DropIndex("dbo.Monsters", new[] { "Gourdin_Id" });
            DropColumn("dbo.Heroes", "Avatar");
            DropTable("dbo.Monsters");
            DropTable("dbo.Gourdins");
        }
    }
}
