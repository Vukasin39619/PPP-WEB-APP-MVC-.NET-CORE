using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP___ProjekatPokusaj2.Core
{
    public class MyAppDbContext : DbContext
    {
      
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ClanBO>Clan { get; set; }
        public DbSet<RacunBO> Racun { get; set; }
        public DbSet<KnjigaBO> Knjiga { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity configurations and relationships can be defined here
            modelBuilder.Entity<ClanBO>().HasKey(v => v.Id_Clana);
            modelBuilder.Entity<RacunBO>().HasKey(c => c.Id_Knjige);
            modelBuilder.Entity<KnjigaBO>().HasKey(s => s.Id_Knjige);
            // Other entity configurations...
        }
    }
}
