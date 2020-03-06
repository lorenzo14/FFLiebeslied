using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;

namespace FFLiebeslied.Models
{
    public class ModelContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Author> Artists { get; set; }
        public virtual DbSet<Disc> Discs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public ModelContext() : base(ConfigurationManager.ConnectionStrings["Intermark"].ConnectionString)
        {

        }

    }
}
