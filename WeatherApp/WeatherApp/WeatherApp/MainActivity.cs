using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using WeatherApp.Service;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        SearchView citySearch;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var cityTextView = FindViewById<TextView>(Resource.Id.cityTextView);
            var tempTextView = FindViewById<TextView>(Resource.Id.tempTextView);
            var weatherImage = FindViewById<ImageView>(Resource.Id.weatherImage);
            citySearch = FindViewById<SearchView>(Resource.Id.citySearchView);
            

            var weatherService = new WeatherService();
            citySearch.SearchClick += citySearch_Click;
            var cityText = citySearch.ToString;

            var weatherInfo = await weatherService.GetCityWeather(cityText);
            cityTextView.Text = weatherInfo.Name;
            tempTextView.Text = weatherInfo.Main.Temp.ToString();

            weatherImage.SetImageBitmap(await weatherService.GetImageFromUrl($"https://openweathermap.org/img/wn/{weatherInfo.Weather[0].Icon}@2x.png"));
        }
        public void citySearch_Click(object sender, EventArgs e)
        {
            
            var citySearchView = FindViewById<SearchView>(Resource.Id.citySearchView);
            string searchText = citySearchView.ToString();
            
            citySearch = searchText;
            

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}