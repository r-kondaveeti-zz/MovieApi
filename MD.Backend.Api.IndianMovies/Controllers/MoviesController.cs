using System;
using System.Collections.Generic;
using System.Linq;
using MD.Backend.Api.IndianMovies.Db;
using MD.Backend.Api.IndianMovies.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MD.Backend.Api.IndianMovies.Controllers
{
    [ApiController]
    [Route("api/movies/")]
    public class MoviesController: ControllerBase
    {
        private readonly MoviesDbContext _context;

        private readonly IMoviesProvider _moviesProvider;

        public MoviesController(MoviesDbContext context, IMoviesProvider moviesProvider)
        {
            _context = context;
            _moviesProvider = moviesProvider;
        }

        [HttpGet("search/indian/{title}")]
        public IActionResult GetMovie(string title)
        {
            title = title.ToLower();

            var movie = _moviesProvider.GetMovie(title);
            if (movie == null) return BadRequest();
            return Ok(movie);
        }

        [HttpGet("{language}/{pageNumber:int}")]
        public IActionResult GetFilms(string language, int pageNumber)
        {
            var movies = _moviesProvider.GetMovies(language, pageNumber);
            if (movies == null) return BadRequest();
            return Ok(movies);
        }

        [HttpGet("{language}/{year:int}/{pageNumber:int}")]
        public IActionResult GetFilmsWithYear(string language, int year, int pageNumber)
        {
            var movies = _moviesProvider.GetMovies(language, year, pageNumber);
            if (movies == null) return BadRequest();
            return Ok(movies);
        }

    }
}
