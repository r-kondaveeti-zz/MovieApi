using System;
using System.Collections.Generic;

namespace MD.Backend.Api.EnglishMovies.Utility
{
    public class Converter
    {
        public static Models.Movie ConvertToResponse(Services.Movie fromMovie)
        {
            Models.Movie toMovie = new Models.Movie
            {
                Name = fromMovie.title,
                Synopsis = fromMovie.description_full,
                Year = fromMovie.year,
                Poster = fromMovie.medium_cover_image,
                Torrent = fromMovie.torrents[0].quality == "720p" ? fromMovie.torrents[0].url : null,
                Languages = new List<string> { fromMovie.language },
                Genres = fromMovie.genres,
                Actors = null,
                Directors = null
            };

            return toMovie;
        }
    }
}
