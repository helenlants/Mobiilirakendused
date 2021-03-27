using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Xamarin.Essentials;

namespace FirstApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var textView = FindViewById<TextView>(Resource.Id.textView1);
            var textView2 = FindViewById<TextView>(Resource.Id.textView2);
            var button = FindViewById<Button>(Resource.Id.button1);
            var calculatorButton = FindViewById<Button>(Resource.Id.calculatorButton);
            var webButton = FindViewById<Button>(Resource.Id.webButton);
            var mapButton = FindViewById<Button>(Resource.Id.mapButton);
            var toListActivityButton = FindViewById<Button>(Resource.Id.toListButton);
 

            var device = DeviceInfo.Model;
            textView2.Text = device.ToString();

            button.Click += delegate
            {
                //textView.Text = "Hello World!";
                var level = Battery.ChargeLevel;
                textView.Text = level.ToString();

            };
            int count = 1;
            button.Click += delegate {
                button.Text = string.Format("{0} clicks!", count++);
            };

            calculatorButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(CalculatorActivity));
                StartActivity(intent);
            };
            webButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(WebActivity));
                intent.PutExtra(Constants.AddressKey, Constants.DefaultUrlToLoad);
                StartActivity(intent);
            };
            mapButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(mapActivity));
                StartActivity(intent);
            };
            toListActivityButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(SampleListActivity)); //activity nimi siia
                StartActivity(intent);
            };


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}