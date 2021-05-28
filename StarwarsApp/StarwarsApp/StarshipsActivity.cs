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
    [Activity(Label = "StarshipsActivity")]
    public class StarshipsActivity : Activity
    {
        Starships starshipsdata = new Starships();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.starships_layout);

            var remoteDataService = new RemoteDataService();
            starshipsdata = await remoteDataService.GetStarwarsStarships();

            var starshipslistview = FindViewById<ListView>(Resource.Id.starshipsListView);
            starshipslistview.Adapter = new StarshipsAdapter(this, starshipsdata.results);
            starshipslistview.ItemClick += OnListItemClick;

        }
        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var rowNumberClick = e.Position;

            var t = starshipsdata.results[rowNumberClick];

            var intent = new Intent(this, typeof(StarshipsDetailActivity));
            intent.PutExtra("StarshipsDetail", JsonConvert.SerializeObject(t));
            StartActivity(intent);
        }

    }
}