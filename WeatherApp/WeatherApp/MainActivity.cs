using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using WeatherApp.ListAdapters;
using WeatherApp.Service;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        String _cityEditText;
        ImageView _weatherImage;
        TextView _cityTextView;
        TextView _tempTextView;
        ListView _forecastListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _cityTextView = FindViewById<TextView>(Resource.Id.cityTextView);
            _tempTextView = FindViewById<TextView>(Resource.Id.tempTextView);
            _weatherImage = FindViewById<ImageView>(Resource.Id.weatherImage);

            _cityTextView.Visibility = Android.Views.ViewStates.Invisible;
            _tempTextView.Visibility = Android.Views.ViewStates.Invisible;
            _weatherImage.Visibility = Android.Views.ViewStates.Invisible;

            var citySearchButton = FindViewById<Button>(Resource.Id.citySearchButton);
            citySearchButton.Click += citySearch_Click;
        }
        public async void citySearch_Click(object sender, EventArgs e)
        {

            _forecastListView = FindViewById<ListView>(Resource.Id.forecastListView);
            _cityEditText = FindViewById<EditText>(Resource.Id.cityEditText).Text;


            var weatherService = new WeatherService();
            var weatherInfo = await weatherService.GetCityWeather($"{_cityEditText}");

            _cityTextView.Text = weatherInfo.Name;
            _tempTextView.Text = weatherInfo.Main.Temp.ToString();

            _weatherImage.SetImageBitmap(await weatherService.GetImageFromUrl($"https://openweathermap.org/img/wn/{weatherInfo.Weather[0].Icon}@2x.png"));
            _weatherImage.Visibility = Android.Views.ViewStates.Visible;

            var weatherForecast = await weatherService.GetCityWeatherForecast($"{_cityEditText}");
            _forecastListView.Adapter = new ForecastListAdapter(this, weatherForecast.list);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}