using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FFLiebeslied.Models
{

    //Clase de modelo de Disco
    public class Disc
    {
        [Key]
        [Required(ErrorMessage = "Se requiere un id")]
        public int idDisc { get; set;  }

        public double Price { get; set; }

        //Relación con las canciones que contiene
        public List<Song> Songs { get; set; }

        public byte[] DiscImage { get; set; }
    }
}
