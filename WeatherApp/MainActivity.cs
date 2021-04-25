using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net.Http;
using WeatherApp.Services;
using Android.Graphics;
using System;
using WeatherApp.Models;
using System.Collections.Generic;
using Android.Views;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        List<WeatherData> items;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            var dataService = new RemoteDataService();

            var cityEditText = FindViewById<EditText>(Resource.Id.cityTextView);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var tempTextView = FindViewById<TextView>(Resource.Id.tempTextView);
            var hum_windTextView = FindViewById<TextView>(Resource.Id.hum_windTextView);
            var weatherImage = FindViewById<ImageView>(Resource.Id.weatherImage);
            var listView = FindViewById<ListView>(Resource.Id.listView1);

            searchButton.Click += async delegate
            {
                var data = await dataService.GetCityWeather(cityEditText.Text);
                var fivedata = await dataService.GetCityfiveday(cityEditText.Text);
                tempTextView.Text = $"{data.main.temp.ToString()} C";

                var bm = await dataService.GetImageFromUrl($"https://openweathermap.org/img/wn/{data.weather[0].icon}@2x.png");
                var bitmap = await BitmapFactory.DecodeByteArrayAsync(bm, 0, bm.Length);
                weatherImage.SetImageBitmap(bitmap);

                hum_windTextView.Text = $"Humidity:{data.main.humidity.ToString()} % " + $"Wind:{Math.Round(data.wind.speed).ToString()} m/s";

                DateTime thisDay = DateTime.Today;

                items = new List<WeatherData>
                    {
                        new WeatherData { time = thisDay.AddDays(1).DayOfWeek.ToString(), temp = "Temperature: " + Math.Round(fivedata.list[7].main.temp).ToString() + " °C", windfive = "Wind: " + Math.Round(fivedata.list[4].wind.speed).ToString()+ " m/s", humidityfive = "Humidity: " + fivedata.list[4].main.humidity.ToString() + " %"},
                        new WeatherData { time = thisDay.AddDays(2).DayOfWeek.ToString(), temp = "Temperature: " + Math.Round(fivedata.list[15].main.temp).ToString() + " °C", windfive = "Wind: " + Math.Round(fivedata.list[9].wind.speed).ToString()+ " m/s", humidityfive = "Humidity: " + fivedata.list[9].main.humidity.ToString() + " %"},
                        new WeatherData { time = thisDay.AddDays(3).DayOfWeek.ToString(), temp = "Temperature: " + Math.Round(fivedata.list[23].main.temp).ToString() + " °C", windfive = "Wind: " + Math.Round(fivedata.list[14].wind.speed).ToString()+ " m/s", humidityfive = "Humidity: " + fivedata.list[14].main.humidity.ToString() + " %"},
                        new WeatherData { time = thisDay.AddDays(4).DayOfWeek.ToString(), temp = "Temperature: " + Math.Round(fivedata.list[31].main.temp).ToString() + " °C", windfive = "Wind: " + Math.Round(fivedata.list[19].wind.speed).ToString()+ " m/s", humidityfive = "Humidity: " + fivedata.list[19].main.humidity.ToString() + " %"},
                        new WeatherData { time = thisDay.AddDays(5).DayOfWeek.ToString(), temp = "Temperature: " + Math.Round(fivedata.list[39].main.temp).ToString() + " °C", windfive = "Wind: " + Math.Round(fivedata.list[24].wind.speed).ToString()+ " m/s", humidityfive = "Humidity: " + fivedata.list[24].main.humidity.ToString() + " %"},

                    };
                listView.Adapter = new DataAdapter(this, items);
            };


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}