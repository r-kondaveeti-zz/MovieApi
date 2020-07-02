using System;
using System.Collections.Generic;

namespace MD.Backend.Api.IndianMovies.Models
{
    public class Movie
    {
        public string Name { get; set; }

        public string Synopsis { get; set; }

        public int Year { get; set; }

        public string Poster { get; set; }

        public string Torrent { get; set; }

        public ICollection<string> Languages { get; set; }

        public ICollection<string> Genres { get; set; }

        public ICollection<string> Actors { get; set; }

        public ICollection<string> Directors { get; set; }
    }
}
