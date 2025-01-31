using System.ComponentModel.DataAnnotations;

namespace Agence_voyage.Models
{
    public class Annonce
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La description est obligatoire")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Le statut est obligatoire")]
        [StringLength(50)]
        public string Statut { get; set; }

        public int TypeOffre { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire")]
        [Range(0, double.MaxValue, ErrorMessage = "Le prix doit être positif")]
        public decimal Prix { get; set; }



        [Required]
        public DateTime DateDepart { get; set; }

        [Required]
        public DateTime DateArrivee { get; set; }

        [Required]
        public TimeSpan HeureDepart { get; set; }

        [Required]
        public TimeSpan HeureArrivee { get; set; }

        [Required]
        [StringLength(100)]
        public string LocaliteDepart { get; set; }

        public int? FlotteId { get; set; }
        public virtual Flotte Flotte { get; set; }
    }
}