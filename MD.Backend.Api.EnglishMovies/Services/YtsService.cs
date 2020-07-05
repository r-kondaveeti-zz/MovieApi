using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MD.Backend.Api.EnglishMovies.Services
{
    public class YtsService: Interfaces.IYtsService
    {
        private readonly HttpClient _client;

        public YtsService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("Default");
        }

        public async Task<IList<Models.Movie>> GetMoviesUsingGenreAsync(string genre, int pageNumber)
        {
            var response = await _client.GetAsync($"api/v2/list_movies.json?genre={genre}&page={pageNumber}");
            if(response.IsSuccessStatusCode)
            {
                var repository = JsonSerializer.DeserializeAsync<Repository>(await response.Content.ReadAsStreamAsync()).Result;

                var fromMovies = repository.Data.Movies;
                var toMovies = new List<Models.Movie>();
                if (fromMovies is null || fromMovies.Count <= 0) return null;
                foreach (var fromMovie in fromMovies)
                {
                    toMovies.Add(Utility.Converter.ConvertToResponse(fromMovie));
                }

                return toMovies;
            }

            return null;
        }
    }
}
