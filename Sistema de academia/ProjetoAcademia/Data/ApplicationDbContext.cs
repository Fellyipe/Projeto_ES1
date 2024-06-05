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

    public DbSet<T> GetDbSet<T>() where T : class
    {
        return Set<T>();
    }
}
