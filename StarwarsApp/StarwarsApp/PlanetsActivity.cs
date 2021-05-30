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
    [Activity(Label = "PlanetsActivity")]
    public class PlanetsActivity : Activity
    {
        Planets planetsdata = new Planets();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.planets_layout);

            var remoteDataService = new RemoteDataService();
            planetsdata = await remoteDataService.GetStarwarsPlanets();

            var planetslistview = FindViewById<ListView>(Resource.Id.planetsListView);
            planetslistview.Adapter = new PlanetsAdapter(this, planetsdata.results);
            planetslistview.ItemClick += OnListItemClick;
        }
        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var rowNumberClick = e.Position;

            var t = planetsdata.results[rowNumberClick];

            var intent = new Intent(this, typeof(PlanetsDetailActivity));
            intent.PutExtra("PlanetsDetail", JsonConvert.SerializeObject(t));
            StartActivity(intent);
        }
    }
}