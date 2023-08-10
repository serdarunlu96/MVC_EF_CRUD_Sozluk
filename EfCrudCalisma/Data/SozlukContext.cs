using Microsoft.EntityFrameworkCore;

namespace EfCrudCalisma.Data
{
    public class SozlukContext : DbContext
    {
        public SozlukContext(DbContextOptions<SozlukContext> options) : base(options)
        {
            
        }

        public DbSet<Girdi> Girdiler => Set<Girdi>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Girdi>().HasData(
                new Girdi { Id = 1, Sozcuk = "Book", Anlam = "Kitap" },
                new Girdi { Id = 2, Sozcuk = "Computer", Anlam = "Bilgisayar" },
                new Girdi { Id = 3, Sozcuk = "Sun", Anlam = "Güneş" },
                new Girdi { Id = 4, Sozcuk = "Car", Anlam = "Araba" }
            );
        }
    }
}
