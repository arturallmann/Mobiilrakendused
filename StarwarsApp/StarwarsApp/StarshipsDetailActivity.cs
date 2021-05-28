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
    [Activity(Label = "StarshipsDetailActivity")]
    public class StarshipsDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.starships_detail_layout);

            var nameText = FindViewById<TextView>(Resource.Id.nameTextView);
            var modelText = FindViewById<TextView>(Resource.Id.modelTextView);
            var manufacturerText = FindViewById<TextView>(Resource.Id.manufacturerTextview);
            var costText = FindViewById<TextView>(Resource.Id.costTextview);
            var lengthText = FindViewById<TextView>(Resource.Id.lengthTextview);
            var maxSpeedText = FindViewById<TextView>(Resource.Id.maxSpeedTextview);
            var crewText = FindViewById<TextView>(Resource.Id.crewTextview);
            var passengersText = FindViewById<TextView>(Resource.Id.passengersTextview);
            var consumablesText = FindViewById<TextView>(Resource.Id.consumablesTextview);
            var hyperdriveText = FindViewById<TextView>(Resource.Id.hyperdriveTextview);
            var cargoText = FindViewById<TextView>(Resource.Id.cargoTextview);
            var mgltText = FindViewById<TextView>(Resource.Id.mgltTextview);
            var starshipClassText = FindViewById<TextView>(Resource.Id.starshipClassTextview);

            var StarshipsDetailJson = Intent.GetStringExtra("StarshipsDetail");
            var details = JsonConvert.DeserializeObject<StarshipsDetails>(StarshipsDetailJson);

            nameText.Text += details.name;
            modelText.Text += details.model;
            manufacturerText.Text += details.manufacturer;
            costText.Text += details.cost_in_credits;
            lengthText.Text += details.length;
            maxSpeedText.Text += details.max_atmosphering_speed;
            crewText.Text += details.crew;
            passengersText.Text += details.passengers;
            consumablesText.Text += details.consumables;
            hyperdriveText.Text += details.hyperdrive_rating;
            cargoText.Text += details.cargo_capacity;
            mgltText.Text += details.MGLT;
            starshipClassText.Text += details.starship_class;
            // Create your application here
        }
    }
}
