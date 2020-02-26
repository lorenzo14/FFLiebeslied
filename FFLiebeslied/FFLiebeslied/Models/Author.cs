using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FFLiebeslied.Models
{
    //Clase de modelo Autor
    public class Author
    {
        [Key]
        [Required(ErrorMessage = "Se requiere un id")]
        [Column(Order = 1)]
        public int idAuthor { get; set; }

        [Required(ErrorMessage = "Se requiere un nombre")]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public string MainGenre { get; set; }
        public byte[] AuthorImage { get; set; }

        //Relación con los miembros del grupo
        public List<Member> Members { get; set; }

    }
}
