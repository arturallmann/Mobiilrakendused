﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarwarsApp.Models
{

    public class Planets
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<PlanetsDetails> results { get; set; }
    }
}