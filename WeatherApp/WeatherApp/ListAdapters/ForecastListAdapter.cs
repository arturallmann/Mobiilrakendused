using System;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using WeatherApp.Models;
using WeatherApp.Service;
using System.Threading.Tasks;

namespace WeatherApp.ListAdapters
{
    public class ForecastListAdapter : BaseAdapter<WeatherItem>
    {
        List<WeatherItem> _items;
        Activity _context;
        

        public ForecastListAdapter(Activity context, List<WeatherItem> items)
        {
            _items = items;
            _context = context;
        }


        public override WeatherItem this[int position]
        {
            get { return _items[position]; }
        }

        public override int Count
        {
            get { return _items.Count; }
        }
        public override long GetItemId(int position)
        {
            return position;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var weatherService = new WeatherService();
            var weatherInfo = weatherService.GetCityWeather(_items[position].ToString());
            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.forecast_row_layout, null);
            view.FindViewById<TextView>(Resource.Id.forecastTimeTextView).Text = _items[position].dt_txt;
            view.FindViewById<TextView>(Resource.Id.forecastTempTextView).Text = _items[position].main.Temp.ToString();
            view.FindViewById<ImageView>(Resource.Id.forecastImage).SetImageBitmap(weatherService.GetImageFromUrl($"https://openweathermap.org/img/wn/{weatherInfo.Weather[position].Icon}@2x.png"));
            return view;
        }
    }

}