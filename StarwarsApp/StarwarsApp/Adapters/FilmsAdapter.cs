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
    public class FilmsAdapter : BaseAdapter<FilmsDetails>
    {
        List<FilmsDetails> _items;
        Activity _context;

        public FilmsAdapter(Activity context, List<FilmsDetails> items)
        {
            _items = items;
            _context = context;
        }

        public override FilmsDetails this[int position]
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
                view = _context.LayoutInflater.Inflate(Resource.Layout.films_row_layout, null);
            view.FindViewById<TextView>(Resource.Id.titleTextView).Text = _items[position].title;
            view.FindViewById<TextView>(Resource.Id.releaseDateTextView).Text = _items[position].release_date;

            return view;
        }
    }
}