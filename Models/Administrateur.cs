using System.ComponentModel.DataAnnotations.Schema;

namespace Agence_voyage.Models
{
    [Table("Administrateurs")]
    public class Administrateur : Utilisateur
    {
        public virtual ICollection<Utilisateur> UtilisateursGeres { get; set; } = new List<Utilisateur>();
    }
}