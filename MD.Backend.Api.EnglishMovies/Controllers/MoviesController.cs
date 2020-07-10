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
        private readonly Interfaces.IYtsService _ytsService;

        public MoviesController(Interfaces.IYtsService ytsService)
        {
            _ytsService = ytsService;
        }

        [HttpGet("{genre}/{pageNumber:int}")]
        public async Task<IActionResult> GetMoviesUsingGenreAsync(string genre, int pageNumber)
        {
           var movies = await _ytsService.GetMoviesUsingGenreAsync(genre, pageNumber);
           if (movies is null || movies.Count <= 0) return NotFound();
           return Ok(movies);
        }
        
        [HttpGet("{searchTerm}")]
        public async Task<IActionResult> GetMoviesUsingGenreAsync(string searchTerm)
        {
            var movies = await _ytsService.GetMoviesUsingSearchTermAsync(searchTerm);
            if (movies is null || movies.Count <= 0) return NotFound();
            return Ok(movies);
        }
    }
}
