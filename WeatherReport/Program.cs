using System;
using System.Threading.Tasks;

namespace WeatherReport
{
    class Program
    {
        static void Main(string[] args)
        {

            prompt().Wait();

            Console.ReadLine();

        }

        public static async Task prompt()
        {
            Console.WriteLine("Please enter a location: ");
            string location = Console.ReadLine();
            API googleAPI = new API($"https://maps.googleapis.com/maps/api/geocode/json?address={location}&key=AIzaSyAwpuRa3cWO-DSZyx7r5PhrHPzQw1wFpAQ");
            GoogleRootObject googleData = await googleAPI.GetData<GoogleRootObject>();
            var latlng = String.Format("{0},{1}", googleData.results[0].geometry.location.lat, googleData.results[0].geometry.location.lng);
            API darkSkyAPI = new API($"https://api.darksky.net/forecast/2fa70440f4d9a4c2dcb935a849825cc2/{latlng}");
            DarkSkyRootObject darkSkyData = await darkSkyAPI.GetData<DarkSkyRootObject>();
            printCurrentConditions(darkSkyData);
            printExtendedForecast(darkSkyData);

        }


        public static DateTime ConvertFromUnixTimeToDateTime (double unixTimeStamp)
        {
            System.DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dt = dt.AddSeconds(unixTimeStamp).ToLocalTime();
            return dt;
        }

        public static void printCurrentConditions(DarkSkyRootObject w)
        {
            Console.WriteLine();
            Console.WriteLine("Current Conditions:");
            Console.WriteLine("{0}° F", w.currently.temperature.ToString(".#"));
            Console.WriteLine("Chance of precipitation: {0}%", w.currently.precipProbability.ToString());
            Console.WriteLine("Visibility: {0} miles", w.currently.visibility);
            Console.WriteLine("Barometric Pressure: {0} millibars", w.currently.pressure);
            Console.WriteLine(w.currently.summary);
            Console.WriteLine();

        }

        public static void printExtendedForecast(DarkSkyRootObject w)
        {
            Console.WriteLine("Extended Forecast:");
            for (int i = 1; i < 8; i++)
            {
                var weekDay = ConvertFromUnixTimeToDateTime(w.daily.data[i].time);
                Console.WriteLine("Weekday: {0}", weekDay.DayOfWeek);
                var sunRiseTime = ConvertFromUnixTimeToDateTime(w.daily.data[i].sunriseTime);
                Console.WriteLine("Sunrise: {0}", sunRiseTime.ToShortTimeString());
                var sunSetTime = ConvertFromUnixTimeToDateTime(w.daily.data[i].sunsetTime);
                Console.WriteLine("Sunset:  {0}", sunSetTime.ToShortTimeString());
                Console.WriteLine(w.daily.data[i].summary);
                Console.WriteLine("-----------------------------------------------------------");
            }
        }



    }

    
    


}
