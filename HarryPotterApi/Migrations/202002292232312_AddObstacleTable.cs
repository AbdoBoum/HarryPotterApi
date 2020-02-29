namespace HarryPotterApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddObstacleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Obstacles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionY = c.Int(nullable: false),
                        PositionX = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Obstacles");
        }
    }
}
