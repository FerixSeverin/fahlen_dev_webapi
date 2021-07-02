using fahlen_dev_webapi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace fahlen_dev_webapi.Data
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> opt) : base(opt) {

        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Email)
                .IsUnique();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeGroup> RecipeGroup { get; set; }
        public DbSet<Measure> Measure { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
    }
}