using System.Collections.Generic;

namespace WeatherReport
{
    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }


    public class Geometry
    {
        public Location location { get; set; }
    }

    public class Result
    {
        public Geometry geometry { get; set; }
    }

    public class GoogleRootObject
    {
        public List<Result> results { get; set; }
    }

    public class Currently
    {
        public int time { get; set; }
        public string summary { get; set; }
        
        public decimal precipProbability { get; set; }
        public double temperature { get; set; }
        public double apparentTemperature { get; set; }
        public double visibility { get; set; }
        public double pressure { get; set; }
        public double ozone { get; set; }
    }

    public class Datum
    {
        public int time { get; set; }
        public float precipIntensity { get; set; }
        public decimal precipProbability { get; set; }
    }


    public class Datum3
    {
        public int time { get; set; }
        public string summary { get; set; }
        public int sunriseTime { get; set; }
        public int sunsetTime { get; set; }
        public double precipProbability { get; set; }
    }

    public class Daily
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<Datum3> data { get; set; }
    }


    public class DarkSkyRootObject
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        public int offset { get; set; }
        public Currently currently { get; set; }
        public Daily daily { get; set; }
    }
}
