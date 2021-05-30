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
    [Activity(Label = "FilmsDetailActivity")]
    public class FilmsDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.films_detail_layout);

            var titleText = FindViewById<TextView>(Resource.Id.titleTextView);
            var episodeText = FindViewById<TextView>(Resource.Id.episodeTextview);
            var descriptionText = FindViewById<TextView>(Resource.Id.descriptionTextview);
            var directorText = FindViewById<TextView>(Resource.Id.directorTextview);
            var producerText = FindViewById<TextView>(Resource.Id.producerTextview);
            var releaseText = FindViewById<TextView>(Resource.Id.releaseDateTextView);

            var FilmsDetailJson = Intent.GetStringExtra("FilmsDetail");
            var details = JsonConvert.DeserializeObject<FilmsDetails>(FilmsDetailJson);

            titleText.Text += details.title;
            episodeText.Text += details.episode_id;
            descriptionText.Text += details.opening_crawl;
            producerText.Text += details.producer;
            directorText.Text += details.director;
            releaseText.Text += details.release_date;
            // Create your application here

        }
    }
}