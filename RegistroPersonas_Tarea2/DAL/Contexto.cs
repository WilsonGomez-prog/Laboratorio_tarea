using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public DbSet<Personas> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite(@"Data Source=DATA\Personas.db");
    }
}