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
    public class StarshipsAdapter : BaseAdapter<StarshipsDetails>
    {
        List<StarshipsDetails> _items;
        Activity _context;

        public StarshipsAdapter(Activity context, List<StarshipsDetails> items)
        {
            _items = items;
            _context = context;
        }

        public override StarshipsDetails this[int position]
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
                view = _context.LayoutInflater.Inflate(Resource.Layout.starships_row_layout, null);
            view.FindViewById<TextView>(Resource.Id.nameTextView).Text = _items[position].name;
            view.FindViewById<TextView>(Resource.Id.modelTextView).Text = _items[position].model;

            return view;
        }
    }
}