using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FFLiebeslied.Models
{
    public class Order
    {
        [Key]
        public DateTime OrderDate { get; set; }
        public string Adress { get; set; }
        public int CP { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }

        public virtual Disc Disc { get; set; }
        public virtual User User { get; set; }
    }
}
