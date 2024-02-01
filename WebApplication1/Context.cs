using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace serwis_drugi
{
    public class Context : DbContext
    {
        public string DbPath { get; }

        public DbSet<Czesc> Czesci { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Naprawa> Naprawy { get; set; }
        public DbSet<Narzedzie> Narzedzia { get; set; }
        public DbSet<PracownikSerwisu> PracownicySerwisu { get; set; }
        public DbSet<Rower> Rowery { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source=database.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Czesc>().HasKey(x => x.ID);
            modelBuilder.Entity<Klient>().HasKey(x => x.ID);
            modelBuilder.Entity<Naprawa>().HasKey(x => x.ID);
            modelBuilder.Entity<Narzedzie>().HasKey(x => x.ID);
            modelBuilder.Entity<PracownikSerwisu>().HasKey(x => x.ID);
            modelBuilder.Entity<Rower>().HasKey(x => x.ID);
        }

    }
}