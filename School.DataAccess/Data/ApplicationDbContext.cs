using Microsoft.EntityFrameworkCore;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Students> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Classes> classes { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<City> cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>()
               .HasOne(s => s.classes)
               .WithMany()
               .HasForeignKey(s => s.ClassId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Students>()
                .HasOne(s => s.country)
                .WithMany()
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Students>()
                .HasOne(s => s.state)
                .WithMany()
                .HasForeignKey(s => s.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Students>()
                .HasOne(s => s.city)
                .WithMany()
                .HasForeignKey(s => s.CityId)
                .OnDelete(DeleteBehavior.Restrict);

           
        }


    }
}
