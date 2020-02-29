namespace HarryPotterApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHeroesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heroes", "Description");
        }
    }
}
