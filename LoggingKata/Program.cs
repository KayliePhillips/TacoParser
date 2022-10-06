using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Runtime.ExceptionServices;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // DONE Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // DONE Grab an IEnumerable of locations using the Select command:
            //      var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // DONE Create two `ITrackable` variables with initial values of `null`.
            // DONE  These will be used to store your two taco bells that are the farthest from each other.
            // DONE  Create a `double` variable to store the distance

            // DONE  Include the Geolocation toolbox, so you can compare locations:
            // //`using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // DONE  Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

            // DONE Create a new corA Coordinate with your locA's lat and long

            // DONE Now, do another loop on the locations with the scope of your first loop,
            //      so you can grab the "destination" location (perhaps: `locB`)

            // DONE  Create a new Coordinate with your locB's lat and long

            // DONE Now, compare the two using `.GetDistanceTo()`, which returns a double
            // DONE If the distance is greater than the currently saved distance, update the distance
            // DONE and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest
            // //away from each other.


            //GeoCoordinate corA = new GeoCoordinate();

            logger.LogInfo("Begin Parsing");

            ITrackable tacoBell1 = new TacoBell();
            ITrackable tacoBell2 = new TacoBell();

            double distance = 0;


            foreach (var locA in locations)
            {

                var corA = new GeoCoordinate()
                {
                    Latitude = locA.Location.Latitude,
                    Longitude = locA.Location.Longitude
                };


                foreach (var locB in locations)
                {
                    var corB = new GeoCoordinate()
                    {
                        Latitude = locB.Location.Latitude,
                        Longitude = locB.Location.Longitude
                    };

                    if (corA.GetDistanceTo(corB)>distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }

                }
            }

            Console.WriteLine($"{tacoBell1.Name} and {tacoBell2.Name} are farthest apart.");

            //convert meters to miles
            var milesApart = Math.Round(distance * 0.000621371, 2);
            Console.WriteLine($"The TacoBells are {milesApart} miles apart.");

            //logger.LogInfo({tacoBell1} { tacoBell2})


            
        }
    }
}
