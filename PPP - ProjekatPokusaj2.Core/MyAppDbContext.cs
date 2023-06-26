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
        public DbSet<VoznjaBO>Voznja { get; set; }
        public DbSet<UlicaBO> Ulica { get; set; }
        public DbSet<KorisnickiNalogBO> KorisnickiNalog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity configurations and relationships can be defined here
            modelBuilder.Entity<VoznjaBO>().HasKey(v => v.Id_voznje);
            modelBuilder.Entity<UlicaBO>().HasKey(c => c.Id_ulice);
            modelBuilder.Entity<KorisnickiNalogBO>().HasKey(s => s.Id);
            // Other entity configurations...
        }
    }
}
