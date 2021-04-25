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

namespace WeatherApp.Models
{
    public class WeatherData
    {
        public string humidityfive { get; set; }

        public string windfive { get; set; }

        public string temp { get; set; }

        public string time { get; set; }
        public static DayOfWeek Today { get; set; }
    }
}