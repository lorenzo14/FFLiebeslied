using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FFLiebeslied.Models
{
    //Clase de modelo Autor
    public class Artist
    {
        [Key]
        [Required(ErrorMessage = "Se requiere un id")]
        [Column(Order = 1)]
        public int idAuthor { get; set; }

        [Required(ErrorMessage = "Se requiere un nombre")]
        public string Name { get; set; }
        public string Country{ get; set; }
        public int Rating{ get; set; }

    }
}
