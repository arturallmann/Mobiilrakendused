using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net.Http;
using Newtonsoft.Json;
using StarwarsApp.Models;
using StarwarsApp.Services;
using StarwarsApp.Adapters;
using System;
using Android.Content;

namespace StarwarsApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            var remoteDataService = new RemoteDataService();
            var peopledata = await remoteDataService.GetStarwarsPeople();
            var filmsdata = await remoteDataService.GetStarwarsFilms();
            var planetsdata = await remoteDataService.GetStarwarsPlanets();
            var starshipsdata = await remoteDataService.GetStarwarsStarships();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //var listview = FindViewById<ListView>(Resource.Id.peopleListView);
            //listview.Adapter = new PeopleAdapter(this, data.results);
            //listview.ItemClick += OnListItemClick;


            var peopleButton = FindViewById<Button>(Resource.Id.peopleButton);
            var filmsButton = FindViewById<Button>(Resource.Id.filmsButton);
            var planetsButton = FindViewById<Button>(Resource.Id.planetsButton);
            var starshipsButton = FindViewById<Button>(Resource.Id.starshipsButton);

            peopleButton.Click += PeopleButton_Click;
            filmsButton.Click += FilmsButton_Click;
            planetsButton.Click += PlanetsButton_Click;
            starshipsButton.Click += StarshipsButton_Click;
        }
        private void PeopleButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(PeopleActivity));
            StartActivity(intent);
        }
        private void FilmsButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(FilmsActivity));
            StartActivity(intent);
        }
        private void PlanetsButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(PlanetsActivity));
            StartActivity(intent);
        }
        private void StarshipsButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(StarshipsActivity));
            StartActivity(intent);
        }
        //private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        //{
        //    var rowNumberThatWasClicked = e.Position;

        //    var t = data.results[rowNumberThatWasClicked];            

        //    var intent = new Intent(this, typeof(DetailActivity));            
        //    intent.PutExtra("PeopleDetail", JsonConvert.SerializeObject(t));
        //    StartActivity(intent);

        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}