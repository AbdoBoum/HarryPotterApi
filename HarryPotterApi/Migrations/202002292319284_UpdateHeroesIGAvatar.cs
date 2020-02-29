namespace HarryPotterApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHeroesIGAvatar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "IGAvatar", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heroes", "IGAvatar");
        }
    }
}
