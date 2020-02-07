namespace HarryPotterApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Heroes", "Epee_Id", "dbo.Epees");
            DropForeignKey("dbo.Monsters", "Gourdin_Id", "dbo.Gourdins");
            DropIndex("dbo.Heroes", new[] { "Epee_Id" });
            DropIndex("dbo.Monsters", new[] { "Gourdin_Id" });
            AddColumn("dbo.Heroes", "EpeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Monsters", "GourdinId", c => c.Int(nullable: false));
            DropColumn("dbo.Heroes", "Epee_Id");
            DropColumn("dbo.Monsters", "Gourdin_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Monsters", "Gourdin_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Heroes", "Epee_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Monsters", "GourdinId");
            DropColumn("dbo.Heroes", "EpeeId");
            CreateIndex("dbo.Monsters", "Gourdin_Id");
            CreateIndex("dbo.Heroes", "Epee_Id");
            AddForeignKey("dbo.Monsters", "Gourdin_Id", "dbo.Gourdins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Heroes", "Epee_Id", "dbo.Epees", "Id", cascadeDelete: true);
        }
    }
}
