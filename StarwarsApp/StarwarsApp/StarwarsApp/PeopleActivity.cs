using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using StarwarsApp.Adapters;
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
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.people_layout);

            var remoteDataService = new RemoteDataService();
            var peopledata = await remoteDataService.GetStarwarsPeople();

            var peoplelistview = FindViewById<ListView>(Resource.Id.peopleListView);
            peoplelistview.Adapter = new PeopleAdapter(this, peopledata.results);
        }
    }
}