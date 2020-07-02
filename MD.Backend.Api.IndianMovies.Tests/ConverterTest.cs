using System.Collections.Generic;
using MD.Backend.Api.IndianMovies.Db;
using NUnit.Framework;

namespace MD.Backend.Api.IndianMovies.Tests
{
    public class ConverterTest
    {
        //Scenarios? -- different type of return elements

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConvertToResponse_DbMovieWithAllTheInfo_ReturnsModelsMovie()
        {
            Db.Movie fromMovie = new Db.Movie
            {
                Name = "Vasu",
                Synopsis = "A lazy guy",
                Year = 2002,
                Torrent = "https://torrent.com",
                Poster = "image.com/vasu",
                Actors = new List<Actor>
                {
                    new Actor { Name = "Venkatesh" }
                },
                Languages = new List<Language>
                {
                    new Language { LanguageType = "Telugu" }
                },
                Directors = new List<Director>
                {
                    new Director { Name = "Dinesh" }
                },
                Genres = new List<Genre>
                {
                    new Genre { GenreType = "Drama" }
                }
            };

            var actualMovie = Utility.Converter.ConvertToResponse(fromMovie);

            Assert.That(actualMovie, Is.InstanceOf<Models.Movie>());
        }

        [Test]
        public void ConvertToResponse_DbMovieWithLanguages_ReturnsModelsMovieWithLanguages()
        {
            Db.Movie fromMovie = new Db.Movie
            {
                Languages = new List<Language>
                {
                    new Language { LanguageType = "Telugu" }
                }
            };

            Models.Movie toMovie = Utility.Converter.ConvertToResponse(fromMovie);

            foreach (var language in toMovie.Languages)
            {
                Assert.That(language, Is.EqualTo("Telugu"));
            }
            
        }

        [Test]
        public void ConvertToResponse_DbMovieWithGenre_ReturnsModelsMovieWithGenres()
        {
            Db.Movie fromMovie = new Db.Movie
            {
                Genres = new List<Genre>
                {
                    new Genre { GenreType = "Drama" }
                }
            };

            Models.Movie toMovie = Utility.Converter.ConvertToResponse(fromMovie);

            foreach (var genre in toMovie.Genres)
            {
                Assert.That(genre, Is.EqualTo("Drama"));
            }

        }

        [Test]
        public void ConvertToResponse_DbMovieWithActor_ReturnsModelsMovieWithActors()
        {
            Db.Movie fromMovie = new Db.Movie
            {
                Actors = new List<Actor>
                {
                    new Actor { Name = "Venkatesh" }
                }
            };

            Models.Movie toMovie = Utility.Converter.ConvertToResponse(fromMovie);

            foreach (var actor in toMovie.Actors)
            {
                Assert.That(actor, Is.EqualTo("Venkatesh"));
            }

        }

        [Test]
        public void ConvertToResponse_DbMovieWithDirector_ReturnsModelsMovieWithDirectors()
        {
            Db.Movie fromMovie = new Db.Movie
            {
                Directors = new List<Director>
                {
                    new Director { Name = "Ravi" }
                }
            };

            Models.Movie toMovie = Utility.Converter.ConvertToResponse(fromMovie);

            foreach (var director in toMovie.Directors)
            {
                Assert.That(director, Is.EqualTo("Ravi"));
            }

        }
    }
}