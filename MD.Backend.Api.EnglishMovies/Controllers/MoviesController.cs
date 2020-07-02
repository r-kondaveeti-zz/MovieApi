using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MD.Backend.Api.EnglishMovies.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        //HttpClient _client;

        private readonly Interfaces.IYtsService _ytsService;

        public MoviesController(Interfaces.IYtsService ytsService)
        {
            //_client = httpClientFactory.CreateClient("Default");
            _ytsService = ytsService;
        }

        //public async Task<IActionResult> GetMoviesAsync()
        //{
        //    var response = _client.GetStreamAsync("api/v2/list_movies.json");
        //    var obj = JsonSerializer.DeserializeAsync<Repository>(await response).Result;
        //    return Ok(Utility.Converter.ConvertToResponse(obj.Data.Movies[0]));
        //}

        [HttpGet("{genre}/{pageNumber:int}")]
        public async Task<IActionResult> GetMoviesUsingGenreAsync(string genre, int pageNumber)
        {
           return Ok(await _ytsService.GetMoviesUsingGenreAsync(genre, pageNumber));
        }
    }
}
