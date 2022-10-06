using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", " Taco Bell Acwort...")]
        public void ShouldParseName(string line, string expected)
        {
            // DONE: Complete Something, if anything

            //Arrange
            var nameParser = new TacoParser();

            //Act
            var actual = nameParser.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Name);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // DONE  Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var longitudeTest = new TacoParser();

            //Act

            var actual = longitudeTest.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);


        }

        //DONE: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)] 
        public void ShouldParseLatitude(string line, double expected)
        {
            //arrange
            var latitudeTest = new TacoParser();

            //act
            var actual = latitudeTest.Parse(line);

            //assert
            Assert.Equal(expected, actual.Location.Latitude);

        }



    }
}
