using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class STContext : DbContext 
    {
        public STContext() : base("name=stconnection")
        {
            Database.SetInitializer<STContext>(null);
        }

        public DbSet<Course> Courses { get; set; }
    }
}