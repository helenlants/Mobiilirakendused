﻿using Android.App;
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
    public class SampleListActivity : Activity //muutsime tüübi ListActivityks alguses ja siis tagasi Activityks, et saaks disaini kasutada. activity ei tea midagi listidest, seega ei saa ka adapterit kasutada ja tuleb disaini fail teha
    {
        string[] items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.simplelist_layout);

            var listView = FindViewById<ListView>(Resource.Id.listView1);
            items = new string[] {"Volkswagen", "BMW", "Fiat" };
            listView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items); //tuli kaasa anda activity-> this, disain, ja see asjade list ehk items

            // Create your application here
        }
    }
}