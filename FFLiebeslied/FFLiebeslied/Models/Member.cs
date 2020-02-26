using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FFLiebeslied.Models
{
    public class Member
    {
        [Key]
        [Required(ErrorMessage = "Se requiere un id")]
        public int idMember { get; set; }
        [Required(ErrorMessage = "Se requiere un nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Se requiere un rol del grupo")]
        public string Role { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public byte[] MemberImage { get; set; }

        //Relación con el grupo al que pertenece
        public virtual Author Group { get; set; }
    }
}
