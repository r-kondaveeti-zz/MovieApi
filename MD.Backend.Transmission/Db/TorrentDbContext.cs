using System;
using Microsoft.EntityFrameworkCore;

namespace MD.Backend.Transmission.Db
{
    public class TorrentDbContext : DbContext
    {
        public TorrentDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Torrent>()
               .HasIndex(t => t.MovieName).IsUnique();

            modelBuilder.Entity<Torrent>()
               .Property(t => t.AddedOn)
               .HasColumnType("datetime2");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("server=localhost;database=movie_downloader_torrents;User ID=SA;password=Reset@123;");

        public DbSet<Torrent> Torrents { get; set; }
    }
}
