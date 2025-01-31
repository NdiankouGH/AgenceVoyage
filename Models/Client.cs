using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agence_voyage.Models
{
    [Table("Clients")]
    public class Client : Utilisateur
    {
        [Required]
        [StringLength(200)]
        public string Adresse { get; set; }

        [Required]
        [StringLength(20)]
        public string NumPasseport { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }

  

  


}