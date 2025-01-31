using Agence_voyage.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Utilisateur> Utilisateurs { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Gestionnaire> Gestionnaires { get; set; }
    public DbSet<Administrateur> Administrateurs { get; set; }
    public DbSet<Agence> Agences { get; set; }
    public DbSet<Offre> Offres { get; set; }
    public DbSet<Voyage> Voyages { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Chauffeur> Chauffeurs { get; set; }
    public DbSet<Flotte> Flottes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().ToTable("Clients");
        modelBuilder.Entity<Gestionnaire>().ToTable("Gestionnaires");
        modelBuilder.Entity<Administrateur>().ToTable("Administrateurs");

        base.OnModelCreating(modelBuilder);
    }
}
