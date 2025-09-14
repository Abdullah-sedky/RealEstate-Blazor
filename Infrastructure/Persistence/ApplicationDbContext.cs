using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Entities;
namespace Infrastructure.Persistence
    {
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }
            public DbSet<Property> Properties { get; set; }
            public DbSet<ManagedProperty> ManagedProperties { get; set; }
            public DbSet<Agent> Agents { get; set; }
            public DbSet<Location> Locations { get; set; }
            public DbSet<City> Cities { get; set; }
            public DbSet<Country> Countries { get; set; }
            public DbSet<Compound> Compounds { get; set; }
            public DbSet<Photo> Photos { get; set; }
            public DbSet<Notification> Notifications { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Property>()
                    .HasOne(p => p.Compound)
                    .WithMany(c => c.Properties)
                    .HasForeignKey(p => p.CompoundId)
                    .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Property>()
                    .HasMany(p => p.Photos)
                    .WithOne(photo => photo.Property)
                    .HasForeignKey(photo => photo.PropertyId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<City>()
                    .HasOne(city => city.Country)
                    .WithMany(cntry => cntry.Cities)
                    .HasForeignKey(city => city.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Property>()
                    .HasOne(p => p.Location)
                    .WithOne()
                    .HasForeignKey<Property>(p => p.LocationId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<City>()
                    .HasMany(c => c.Compounds)
                    .WithOne(comp => comp.City)
                    .HasForeignKey(comp => comp.CityId)
                    .OnDelete(DeleteBehavior.Restrict);

               modelBuilder.Entity<ApplicationUser>() 
                .HasMany(u => u.Properties)
                .WithOne(p => p.User);


                modelBuilder.Entity<Agent>()
                    .ToTable("Agents"); // Separate table for agents
            }
        }
    }
