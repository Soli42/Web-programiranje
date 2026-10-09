namespace WebTemplate.Models;

public class IspitContext : DbContext
{
    public DbSet<Korisnik> Korisnik { get; set; }

    public DbSet<Automobili> Automobili { get; set; }

    public DbSet<Spoj> Spoj { get; set; }

    public IspitContext(DbContextOptions options) : base(options)
    {
        
    }
}
