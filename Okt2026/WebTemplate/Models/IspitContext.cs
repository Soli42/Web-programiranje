namespace WebTemplate.Models;

public class IspitContext : DbContext
{
    // DbSet kolekcije!

    public DbSet<Ansambl> Ansambl { get; set; }

    public DbSet<Clanovi> Clanovi { get; set; }
    public IspitContext(DbContextOptions options) : base(options)
    {
        
    }
}
