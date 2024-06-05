using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Personal> Personal { get; set; }
    public DbSet<Matricula> Matricula { get; set; }
    // Outras propriedades para suas entidades...

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=academia.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Matricula>()
            .HasOne(m => m.Cliente)
            .WithMany()
            .HasForeignKey(m => m.ClienteId);

        modelBuilder.Entity<Matricula>()
            .HasOne(m => m.Personal)
            .WithMany()
            .HasForeignKey(m => m.PersonalId);
    }
}
