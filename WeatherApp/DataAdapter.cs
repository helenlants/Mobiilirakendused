using System;
using System.Collections.Generic;
using Android.Arch.Lifecycle;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WeatherApp.Models;

namespace WeatherApp
{
    public class DataAdapter : BaseAdapter<WeatherData>
    {

        List<WeatherData> _items;
        MainActivity _context;


        public DataAdapter(MainActivity context, List<WeatherData> items)
        {
            _context = context;
            _items = items;

        }

        public DataAdapter(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public override WeatherData this[int position]
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
                view = _context.LayoutInflater.Inflate(Resource.Layout.Listview_layout, null);

            view.FindViewById<TextView>(Resource.Id.windTextView).Text = _items[position].windfive;
            view.FindViewById<TextView>(Resource.Id.humidityfiveTextView).Text = _items[position].humidityfive;
            view.FindViewById<TextView>(Resource.Id.tempTextView).Text = _items[position].temp;
            view.FindViewById<TextView>(Resource.Id.timeTextView).Text = _items[position].time;

            return view;


        }
    }


}