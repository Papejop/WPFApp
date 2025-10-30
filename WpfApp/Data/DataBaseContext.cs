using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Documents> Documents { get; set; } 
        public DbSet<DocumentItem> DocumentItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasKey(doc => doc.Id);

                entity.Property(doc => doc.Type)
                      .HasMaxLength(50).IsRequired();

                entity.Property(doc => doc.FirstName)
                      .HasMaxLength(50).IsRequired();

                entity.Property(doc => doc.LastName)
                      .HasMaxLength(50).IsRequired();

                entity.Property(doc => doc.City)
                      .HasMaxLength(50).IsRequired();

                entity.Property(doc => doc.Date)
                      .IsRequired();

            });


            modelBuilder.Entity<DocumentItem>(entity =>
            {
                entity.HasKey(item => new { item.DocumentId, item.Ordinal });

                entity.Property(item => item.Product)
                      .HasMaxLength(50).IsRequired();

                entity.Property(item => item.Quantity)
                      .HasMaxLength(50).IsRequired();

                entity.Property(item => item.Price)
                      .HasMaxLength(50).IsRequired();

                entity.Property(item => item.TaxRate)
                      .HasMaxLength(50).IsRequired();

                entity.HasOne(item => item.Document)
                      .WithMany(doc => doc.Items)
                      .HasForeignKey(item => item.DocumentId);
            });
        }

    }
}
