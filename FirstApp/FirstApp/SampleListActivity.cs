using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstApp
{
    [Activity(Label = "SampleListActivity")]
    public class SampleListActivity : ListActivity //muutsime tüübi ListActivityks
    {
        string[] items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            items = new string[] {"Volkswagen", "BMW", "Fiat" };
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items); //tuli kaasa anda activity-> this, disain, ja see asjade list ehk items

            // Create your application here
        }
    }
}