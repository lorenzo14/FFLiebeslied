using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FFLiebeslied.Models
{
    public class ModelContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Disc> Discs { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public ModelContext() : base(@"Server=localhost\SQLEXPRESS01;Database=Liebeslied;Trusted_Connection=True;") 
        {

        }

    }
}
