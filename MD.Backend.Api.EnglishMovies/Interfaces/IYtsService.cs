using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MD.Backend.Api.EnglishMovies.Interfaces
{
    public interface IYtsService
    {
        public Task<IList<Models.Movie>> GetMoviesUsingGenreAsync(string genre, int pageNumber);
    }
}
