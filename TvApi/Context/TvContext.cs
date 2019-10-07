using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvApi.Models;

namespace TvApi.Context
{
    public class TvContext : DbContext
    {
        public TvContext(DbContextOptions<TvContext> options): base(options)
        {
        }
        public DbSet<Audience> Audiences { get; set; }
        public DbSet<TvChannel> TvChannels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audience>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Audience>()
                .Property(a => a.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Audience>()
               .HasOne(a => a.TvChannel)
               .WithMany(a => a.Audiences)
               .HasForeignKey(a => a.TvChannelId);

            modelBuilder.Entity<TvChannel>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<TvChannel>()
                .Property(a => a.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TvChannel>()
             .HasIndex(t => t.Name).IsUnique();
        }


        }
}
