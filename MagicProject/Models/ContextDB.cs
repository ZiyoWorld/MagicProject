using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MagicProject.Models
{
    public class ContextDB : DbContext
    {
        public ContextDB() : base("DbRelax12")
        {
            Database.SetInitializer<ContextDB>(new DbInit());
        }

        public DbSet<Profes> Profeses { get; set; }
        public DbSet<Zaynit> Zaynits { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<OrderUser> OrderUsers { get; set; }

    }
}