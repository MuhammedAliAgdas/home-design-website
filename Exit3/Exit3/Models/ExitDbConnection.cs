using Microsoft.EntityFrameworkCore;

namespace Exit3.Models
{
    public class ExitDbConnection : DbContext
    {
        public DbSet<Kullanici>? Kullanicilar { get; set; }
        public DbSet<Yorumlar>? Yorumlar { get; set; }
        //public DbSet<ResimEkleme>? ResimEkleme { get; set; }
        public DbSet<ResimDetaylari>? ResimDetaylari { get; set; }
        public DbSet<Resim>? Resimler { get; set; }
        public DbSet<Paylasim>? Paylasimlar { get; set; }
        public DbSet<Etiket>? Etiketler { get; set; }
        public DbSet<Begeni>? Begeniler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql("server=localhost;port=3306;user=root;password=Melocigo60!;database=Exit5", new MySqlServerVersion(new Version(8, 0, 2)))
                .UseLoggerFactory(LoggerFactory.Create(builder => builder
                    .AddFilter(level => level >= LogLevel.Information)))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}
