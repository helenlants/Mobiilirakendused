using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FirstApp
{
    [Activity(Label = "mapActivity")]
    public class mapActivity : Activity
    {
        WebView _webView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.map_layout);

        }
        public class MapTest
        {
            public async Task NavigateToRaekojaplats()
            {
                var location = new Location(59.43733303333693, 24.744981998257032);
                var options = new MapLaunchOptions { Name = "Raekojaplats" };

                await Map.OpenAsync(location, options);
            }
        }
    }
}