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
    [Activity(Label = "PeopleActivity")]
    public class PeopleActivity : Activity
    {
        People peopledata = new People();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.people_layout);

            var remoteDataService = new RemoteDataService();
            peopledata = await remoteDataService.GetStarwarsPeople();

            var peoplelistview = FindViewById<ListView>(Resource.Id.peopleListView);
            peoplelistview.Adapter = new PeopleAdapter(this, peopledata.results);
            peoplelistview.ItemClick += OnListItemClick;
        }
        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var rowNumberClick = e.Position;

            var t = peopledata.results[rowNumberClick];

            var intent = new Intent(this, typeof(PeopleDetailActivity));
            intent.PutExtra("PeopleDetail", JsonConvert.SerializeObject(t));
            StartActivity(intent);
        }
    }
}