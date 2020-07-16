using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MD.Backend.Api.IndianMovies.Db
{
    public class Movie
    {
        public Movie()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Synopsis { get; set; }

        public int Year { get; set; }

        public string Poster { get; set; }

        public string Torrent { get; set; }

        public ICollection<Language> Languages { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<Director> Directors { get; set; }

        public ICollection<Actor> Actors { get; set; }

        public DateTime AddedOn { get; set; }

    }

    public class Language
    {
        public Language()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string LanguageType { get; set; }
    }

    public class Genre
    {
        public Genre()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string GenreType { get; set; }
    }
    
    public class Actor
    {
        public Actor()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class Director
    {
        public Director()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }

}
