using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;



namespace FirstApp
{
    [Activity(Label = "carimageclick_activity")]
    public class CarImageClickActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.image_click_layout);

            int manufacturerLogo = Convert.ToInt32(Intent.GetStringExtra("logo"));

            FindViewById<ImageView>(Resource.Id.carimageView1).SetImageResource(manufacturerLogo);

        }


    }
}