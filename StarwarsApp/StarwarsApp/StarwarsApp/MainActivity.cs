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
            //var remoteDataService = new RemoteDataService();
            //var peopledata = await remoteDataService.GetStarwarsPeople();
            //var filmsdata = await remoteDataService.GetStarwarsFilms();
            //var starshipsdata = await remoteDataService.GetStarwarsStarships();
            //var planetsdata = await remoteDataService.GetStarwarsPlanets();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //var peoplelistview = FindViewById<ListView>(Resource.Id.peopleListView);
            //peoplelistview.Adapter = new PeopleAdapter(this, peopledata.results);

            //var filmslistview = FindViewById<ListView>(Resource.Id.filmsListView);
            //filmslistview.Adapter = new FilmsAdapter(this, filmsdata.results);

            //var starshipslistview = FindViewById<ListView>(Resource.Id.starshipsListView);
            //starshipslistview.Adapter = new StarshipsAdapter(this, starshipsdata.results);

            //var planetslistview = FindViewById<ListView>(Resource.Id.planetsListView);
            //planetslistview.Adapter = new PlanetsAdapter(this, planetsdata.results);

            var peopleButton = FindViewById<Button>(Resource.Id.peopleButton);
            var filmsButton = FindViewById<Button>(Resource.Id.filmsButton);
            var starshipsButton = FindViewById<Button>(Resource.Id.starshipsButton);
            var planetsButton = FindViewById<Button>(Resource.Id.planetsButton);

            peopleButton.Click += PeopleButton_Click;
            filmsButton.Click += FilmsButton_Click;
            starshipsButton.Click += StarshipsButton_Click;
            planetsButton.Click += PlanetsButton_Click;
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

        private void StarshipsButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(StarshipsActivity));
            StartActivity(intent);
        }

        private void PlanetsButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(PlanetsActivity));
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}