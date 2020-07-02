using System;
using System.Collections.Generic;

namespace MD.Backend.Api.IndianMovies.Interfaces
{
    public interface IMoviesProvider
    {
        Models.Movie GetMovie(string name);

        IList<Models.Movie> GetMovies(string language, int pageNumber);

        IList<Models.Movie> GetMovies(string language, int year, int pageNumber);
    }
}
