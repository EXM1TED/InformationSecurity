using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSecurity.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Jury> juries { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=InformationSecurity.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jury>(entity =>
            {
                entity.ToTable("Juries");
                entity.Property(j => j.Id).ValueGeneratedNever();
            });
        }
    }
}
