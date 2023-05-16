using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        public static void CurrentWeather()
        {
            IConfiguration config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            string apiKey = config.GetSection("AppSettings")["ApiKey"];


            var client = new HttpClient();
            Console.WriteLine("Enter a city Name:");
            var cityName = Console.ReadLine();
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";

            var weatherResponse = client.GetStringAsync(weatherURL).Result;
            var weatherObject = JObject.Parse(weatherResponse);

            Console.WriteLine($"The current weather is: \n {weatherObject["main"]["temp"]} degrees Fahrenheit");

            Console.WriteLine($"{weatherObject["weather"][0]["description"]}");
        }
    }
}
