using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HarryPotterApi.Data
{
    public class HarryPotterApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HarryPotterApiContext() : base("name=HarryPotterApiContext")
        {
        }

        public System.Data.Entity.DbSet<HarryPotterApi.Models.Epee> Epees { get; set; }

        public System.Data.Entity.DbSet<HarryPotterApi.Models.Hero> Heroes { get; set; }

        public System.Data.Entity.DbSet<HarryPotterApi.Models.Gourdin> Gourdins { get; set; }

        public System.Data.Entity.DbSet<HarryPotterApi.Models.Monster> Monsters { get; set; }

        public System.Data.Entity.DbSet<HarryPotterApi.Models.Obstacle> Obstacle { get; set; }

        public System.Data.Entity.DbSet<HarryPotterApi.Models.GameResult> GameResult { get; set; }

    }
}
