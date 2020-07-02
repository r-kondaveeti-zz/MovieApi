using System;
using System.Collections.Generic;

namespace MD.Backend.Api.EnglishMovies.Models
{
    public class Movie
    {
        public string Name { get; set; }

        public string Synopsis { get; set; }

        public int Year { get; set; }

        public string Poster { get; set; }

        public string Torrent { get; set; }

        public IList<string> Languages { get; set; }

        public IList<string> Genres { get; set; }

        public IList<string> Actors { get; set; }

        public IList<string> Directors { get; set; }
    }
}
