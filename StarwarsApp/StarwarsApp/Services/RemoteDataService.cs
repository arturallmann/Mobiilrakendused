using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using StarwarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsApp.Services
{
    public class RemoteDataService
    {
        public async Task<People> GetStarwarsPeople()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://swapi.dev/api/people/");
            People data = null;
            if(response != null)
            {
                data = JsonConvert.DeserializeObject<People>(response);
            }
            return data;         
        }
        public async Task<Films> GetStarwarsFilms()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://swapi.dev/api/films/");
            Films data = null;
            if (response != null)
            {
                data = JsonConvert.DeserializeObject<Films>(response);
            }
            return data;
        }
        public async Task<Ships> GetStarwarsShips()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://swapi.dev/api/ships/");
            Ships data = null;
            if (response != null)
            {
                data = JsonConvert.DeserializeObject<Ships>(response);
            }
            return data;
        }
        public async Task<Planets> GetStarwarsPlanets()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://swapi.dev/api/planets/");
            Planets data = null;
            if (response != null)
            {
                data = JsonConvert.DeserializeObject<Planets>(response);
            }
            return data;
        }
    }
}