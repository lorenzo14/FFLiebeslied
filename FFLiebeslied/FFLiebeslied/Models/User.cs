using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FFLiebeslied.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        
        [Required(ErrorMessage = "Se requiere un nombre de usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Se requiere una contraseña")]
        public string Password { get; set; }

        public Disc Disc { get; set; }
    }
}
