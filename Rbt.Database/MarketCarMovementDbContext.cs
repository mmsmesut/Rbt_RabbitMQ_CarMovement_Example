using Rbt.Database.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbt.Database
{
    public class MarketCarMovementDbContext : DbContext
    {
        public MarketCarMovementDbContext() : base(ConnectionString)
        {

        }

        private static string ConnectionString
        { 
            get
            {
                return ConfigurationManager.ConnectionStrings["MarketCarMovement_Dev"].ConnectionString;
            }
        }

        public DbSet<MarketCarMovement> MarketCarMovements { get; set; }


    }
}
