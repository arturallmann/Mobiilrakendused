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
    [Activity(Label = "PeopleDetailActivity")]
    public class PeopleDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.people_detail_layout);

            var nameText = FindViewById<TextView>(Resource.Id.nameTextview);
            var heightText = FindViewById<TextView>(Resource.Id.heightTextview);
            var weightText = FindViewById<TextView>(Resource.Id.weightTextview);
            var hairColorText = FindViewById<TextView>(Resource.Id.hairColorTextview);
            var skinColorText = FindViewById<TextView>(Resource.Id.skinColorTextview);
            var eyeColorText = FindViewById<TextView>(Resource.Id.eyeColorTextview);
            var birthYearText = FindViewById<TextView>(Resource.Id.birthYearTextview);
            var genderText = FindViewById<TextView>(Resource.Id.genderTextview);

            var PeopleDetailJson = Intent.GetStringExtra("PeopleDetail");
            var details = JsonConvert.DeserializeObject<PeopleDetails>(PeopleDetailJson);

            nameText.Text += details.name;
            heightText.Text += details.height;
            weightText.Text += details.mass;
            hairColorText.Text += details.hair_color;
            skinColorText.Text += details.skin_color;
            eyeColorText.Text += details.eye_color;
            birthYearText.Text += details.birth_year;
            genderText.Text += details.gender;
            // Create your application here
        }
    }
}