using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using StarwarsApp.Adapters;
using StarwarsApp.Models;
using StarwarsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarwarsApp
{
    [Activity(Label = "FilmsActivity")]
    public class FilmsActivity : Activity
    {
        Films filmsdata = new Films();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.films_layout);

            var remoteDataService = new RemoteDataService();
            filmsdata = await remoteDataService.GetStarwarsFilms();

            var filmslistview = FindViewById<ListView>(Resource.Id.filmsListView);
            filmslistview.Adapter = new FilmsAdapter(this, filmsdata.results);
            filmslistview.ItemClick += OnListItemClick;
        }
        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var rowNumberClick = e.Position;

            var t = filmsdata.results[rowNumberClick];

            var intent = new Intent(this, typeof(FilmsDetailActivity));
            intent.PutExtra("FilmsDetail", JsonConvert.SerializeObject(t));
            StartActivity(intent);
        }
    }
}