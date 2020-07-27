using System.Collections.Generic;
using System.Linq;
using MD.Backend.Api.IndianMovies.Db;
using MD.Backend.Api.IndianMovies.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MD.Backend.Api.IndianMovies.Providers
{
    public class MoviesProviders: IMoviesProvider
    {
        private readonly MoviesDbContext _context;

        public MoviesProviders(MoviesDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns Models.Movie matching the provided title
        /// </summary>
        /// <param name="name">Movie Title</param>
        /// <returns>Models.Movie</returns>
        public Models.Movie GetMovie(string name)
        {
            var movie = _context.Movies.Where(m => m.Name == name).Include(m => m.Genres).Include(m => m.Actors).Include(m => m.Languages).Include(m => m.Directors).ToList();
            if (movie.Count > 0 && movie != null) { return Utility.Converter.ConvertToResponse(movie[0]); }

            return null;
        }

        /// <summary>
        /// Returns list of Models.Movie objects matching the provided arguments
        /// </summary>
        /// <param name="language">Language of the movie</param>
        /// <param name="pageNumber">Page number to retrieve</param>
        /// <returns>List of Models.Movie</returns>
        public IList<Models.Movie> GetMovies(string language, int pageNumber)
        {
            var convertedMovies = new List<Models.Movie>();

            pageNumber = (pageNumber - 1) * 10;

            var movies = _context.Movies.Where(m => m.Languages.Any(l => l.LanguageType == language)).
                Include(m => m.Genres).Include(m => m.Actors).
                Include(m => m.Languages).Include(m => m.Directors)
                .OrderByDescending(m => m.AddedOn).Skip(pageNumber).Take(10).ToList();

            if (movies.Count == 0) return null;

            foreach (var movie in movies)
            {
                var convertedMovie = Utility.Converter.ConvertToResponse(movie);
                convertedMovies.Add(convertedMovie);
            }

            return convertedMovies;
        }

        /// <summary>
        /// Returns list of Models.Movie objects matching the provided arguments
        /// </summary>
        /// <param name="language">Language of the movie</param>
        /// <param name="year">Year of the movie</param>
        /// <param name="pageNumber">Page number to retrieve</param>
        /// <returns>List of Models.Movie</returns>
        public IList<Models.Movie> GetMovies(string language, int year, int pageNumber)
        {
            var convertedMovies = new List<Models.Movie>();

            pageNumber = (pageNumber - 1) * 10;

            var movies = _context.Movies.Where(m => m.Languages.Any(l => l.LanguageType == language))
                .Where(m => m.Year == year)
                .Include(m => m.Genres).Include(m => m.Actors)
                .Include(m => m.Languages).Include(m => m.Directors)
                .OrderByDescending(m => m.AddedOn).Skip(pageNumber).Take(10).ToList();

            if (movies.Count == 0) return null;

            foreach (var movie in movies)
            {
                var convertedMovie = Utility.Converter.ConvertToResponse(movie);
                convertedMovies.Add(convertedMovie);
            }

            return convertedMovies;
        }
    }
}
