using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlowerEvidence.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerEvidence.Database
{
    public class FlowerContext : DbContext
    {
        public DbSet<Flower> Flowers { get; set; }
        public FlowerContext()
        {
            Database.EnsureCreated(); //pokud databaze neexistuje, vytvori ji
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=FlowerDb.db"); //nazev databaze
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flower>().HasData(
                new Flower { Id = 1, Name = "Orchidej", Genus = "Chřestotvaré", Color = "Bílá" },
                new Flower { Id = 2, Name = "Tulipán", Genus = "Liliovité", Color = "Žlutá" }
            );
        }
    }
}
