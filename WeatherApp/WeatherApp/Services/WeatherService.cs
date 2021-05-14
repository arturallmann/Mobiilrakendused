using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    class WeatherService
    {
        const string ApiKey = "8c0bf1e3b34c4e6f59c606a301d63c71";

        public async Task<WeatherInfo> GetCityWeather(string city)
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync($"");
            var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(response);
        }
    }
}