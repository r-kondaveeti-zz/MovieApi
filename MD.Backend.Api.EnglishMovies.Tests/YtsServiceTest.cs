using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MD.Backend.Api.EnglishMovies.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeserializeResponse_TaskStream_ReturnsModelsMovie()
        {
            var json = "asdfasdf";
            byte[] byteArray = Encoding.ASCII.GetBytes(json);
            Stream stream = new MemoryStream(byteArray);

            var inputStream = Task.Run(() => stream);


            //Arrange
            var toMovie = Services.YtsServiceHelper.DeserializeResponse(inputStream);

            //Act
            Assert.That(toMovie, Is.InstanceOf<Task<IList<Models.Movie>>>());
        }

    }
}