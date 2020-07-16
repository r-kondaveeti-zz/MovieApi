using System;
using Microsoft.EntityFrameworkCore;

namespace MD.Backend.Api.IndianMovies.Db
{
	public class MoviesDbContext: DbContext
	{
		public MoviesDbContext(DbContextOptions options): base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Movie>()
				.HasIndex(m => m.Name).IsUnique();

            builder.Entity<Movie>()
                .ToTable("Movies");

            builder.Entity<Genre>()
                .ToTable("Genre");

            builder.Entity<Actor>()
                .ToTable("Actor");

            builder.Entity<Director>()
                .ToTable("Director");

            builder.Entity<Language>()
                .ToTable("Language");
        }

		public DbSet<Movie> Movies { get; set; }

		public DbSet<Language> Languages { get; set; }

		public DbSet<Genre> Genres { get; set; }

		public DbSet<Actor> Actors { get; set; }

		public DbSet<Director> Directors { get; set; }

	}
}
