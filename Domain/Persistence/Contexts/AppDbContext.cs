using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trips_Api.Domain.Models;
using Trips_Api.Extensions;

namespace Trips_Api.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Bookmark> Bookmarks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Bookmark>().ToTable("Bookmarks");


            builder.Entity<Bookmark>().HasKey(b => b.Id);
            builder.Entity<Bookmark>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Bookmark>().Property(b => b.Title).IsRequired().HasMaxLength(60);
            builder.Entity<Bookmark>().HasIndex(b => b.Title).IsUnique();
            builder.Entity<Bookmark>().Property(b => b.Latitude).IsRequired();
            builder.Entity<Bookmark>().Property(b => b.Longitude).IsRequired();

            builder.ApplySnakeCaseNamingConvention();
        }
    }
}
