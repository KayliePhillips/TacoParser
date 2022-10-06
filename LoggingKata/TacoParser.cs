namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            
            // DONE Take your line and use line.Split(',') to split it up into an array of strings,
            // separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
               
                logger.LogError("Array length is less than 3");
                return null; // DONE Implement
            }

            // grab the latitude from your array at index 0
            var latitudeParse = double.TryParse(cells[0], out double latitude);

            if (!latitudeParse)
            {
                logger.LogError("Unable to parse latitude.");
            }

            // grab the longitude from your array at index 1
            var longitudeParse = double.TryParse(cells[1], out double longitude);

            if (!longitudeParse)
            {
                logger.LogError("Unable to parse longitude.");
            }

            // grab the name from your array at index 2
            var name = (cells[2]);


            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // DONE You'll need to create a TacoBell class
            //      that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            var locationPoint = new Point()
            {
                Latitude = latitude,
                Longitude = longitude,

            };
            var tacoBell = new TacoBell()
            {
                Name = name,
                Location = locationPoint,
            };

            return tacoBell;

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

           // return null;
        }
    }
}