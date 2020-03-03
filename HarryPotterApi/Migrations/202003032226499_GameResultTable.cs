namespace HarryPotterApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameResultTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Rounds = c.Int(nullable: false),
                        HeroId = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameResults");
        }
    }
}
