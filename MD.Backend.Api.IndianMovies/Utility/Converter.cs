using System;
using System.Collections.Generic;
using MD.Backend.Api.IndianMovies.Db;

namespace MD.Backend.Api.IndianMovies.Utility
{
    public class Converter
    {
        /// <summary>
        /// Converts Db.Movie (DTO) to Models.Movie
        /// </summary>
        /// <param name="fromMovie">Db.Movie</param>
        /// <returns></returns>
        public static Models.Movie ConvertToResponse(Movie fromMovie)
        {
            IList<string> languages = new List<string>();
            IList<string> genres = new List<string>();
            IList<string> actors = new List<string>();
            IList<string> directors = new List<string>();

            Models.Movie toMovie = new Models.Movie
            {
                Name = fromMovie.Name,
                Synopsis = fromMovie.Synopsis,
                Year = fromMovie.Year,
                Poster = fromMovie.Poster,
                Torrent = fromMovie.Torrent,
                AddedOn = fromMovie.AddedOn
            };

            if(fromMovie.Languages != null && fromMovie.Languages.Count != 0)
            {
                foreach (Language language in fromMovie.Languages)
                {
                    languages.Add(language.LanguageType);
                }
            }

            if (fromMovie.Genres != null && fromMovie.Genres.Count != 0)
            {
                foreach (Genre genre in fromMovie.Genres)
                {
                    genres.Add(genre.GenreType);
                }
            }

            if (fromMovie.Actors != null && fromMovie.Actors.Count != 0)
            {
                foreach (Actor actor in fromMovie.Actors)
                {
                    actors.Add(actor.Name);
                }
            }

            if (fromMovie.Directors != null && fromMovie.Directors.Count != 0)
            {
                foreach (Director director in fromMovie.Directors)
                {
                    directors.Add(director.Name);
                }
            }

            toMovie.Languages = languages;
            toMovie.Actors = actors;
            toMovie.Genres = genres;
            toMovie.Directors = directors;

            return toMovie;
        }
    }
}
