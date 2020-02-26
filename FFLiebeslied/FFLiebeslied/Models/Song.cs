using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FFLiebeslied.Models
{
    //Clase Canción para el modelo
    public class Song
    {
        //Campos de la clase
        [Key]
        [Column(Order = 1)]
        public int idSong { get; set; }

        [Required(ErrorMessage = "Se requiere un título para la canción")]
        public string Title { get; set; }
        public string Disc { get; set; }
        public string Genre { get; set; }

        [Required(ErrorMessage = "Se requiere un precio para la canción")]
        public double Price { get; set; }
        public int Year { get; set; }
        public string Lyrics { get; set; }


        //Relación con el autor
        public virtual Author Author { get; set; }
        
    }
}
