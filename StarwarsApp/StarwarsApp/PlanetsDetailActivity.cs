using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using StarwarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarwarsApp
{
    [Activity(Label = "PlanetsDetailActivity")]
    public class PlanetsDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.planets_detail_layout);

            var planetText = FindViewById<TextView>(Resource.Id.planetNameTextView);
            var populationText = FindViewById<TextView>(Resource.Id.populationTextView);
            var rotationText = FindViewById<TextView>(Resource.Id.rotationTextview);
            var orbitText = FindViewById<TextView>(Resource.Id.orbitalTextview);
            var diameterText = FindViewById<TextView>(Resource.Id.diameterTextview);
            var climateText = FindViewById<TextView>(Resource.Id.climateTextview);
            var gravityText = FindViewById<TextView>(Resource.Id.gravityTextview);
            var terrainText = FindViewById<TextView>(Resource.Id.terrainTextview);
            var waterText = FindViewById<TextView>(Resource.Id.waterTextview);

            var PlanetsDetailJson = Intent.GetStringExtra("PlanetsDetail");
            var details = JsonConvert.DeserializeObject<PlanetsDetails>(PlanetsDetailJson);

            planetText.Text += details.name;
            populationText.Text += details.population;
            rotationText.Text += details.rotation_period;
            orbitText.Text += details.orbital_period;
            diameterText.Text += details.diameter;
            climateText.Text += details.climate;
            gravityText.Text += details.gravity;
            terrainText.Text += details.terrain;
            waterText.Text += details.surface_water;

            // Create your application here
        }
    }
}