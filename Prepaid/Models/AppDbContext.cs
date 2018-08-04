using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Prepaid.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext():base ("server=(localdb)\\MSSQLLocalDB;database=CreditsDb;integrated security=true")
        {
                
        }

        public DbSet<Credit> Credits { get; set; }

        public DbSet<User> Users { get; set; }



    }
}