using System.ComponentModel.DataAnnotations.Schema;

namespace Agence_voyage.Models
{
    [Table("Gestionnaires")]
    public class Gestionnaire : Utilisateur
    {
        public virtual ICollection<Agence> Agences { get; set; } = new List<Agence>();
        public virtual ICollection<Offre> Offres { get; set; } = new List<Offre>();
    }
}