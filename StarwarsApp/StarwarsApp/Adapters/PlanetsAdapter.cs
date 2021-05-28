using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using StarwarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarwarsApp.Adapters
{
    public class PlanetsAdapter : BaseAdapter<PlanetsDetails>
    {
        List<PlanetsDetails> _items;
        Activity _context;

        public PlanetsAdapter(Activity context, List<PlanetsDetails> items)
        {
            _items = items;
            _context = context;
        }

        public override PlanetsDetails this[int position]
        {
            get { return _items[position]; }
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.planets_row_layout, null);
            view.FindViewById<TextView>(Resource.Id.planetNameTextView).Text = _items[position].name;
            view.FindViewById<TextView>(Resource.Id.populationTextView).Text = _items[position].population;

            return view;
        }
    }
}