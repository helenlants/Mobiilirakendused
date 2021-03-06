using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstApp
{
    [Activity(Label = "SampleListActivity")]
    public class SampleListActivity : Activity //muutsime tüübi ListActivityks alguses ja siis tagasi Activityks, et saaks disaini kasutada. activity ei tea midagi listidest, seega ei saa ka adapterit kasutada ja tuleb disaini fail teha
    {
        List<Car> items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.simplelist_layout);

            var listView = FindViewById<ListView>(Resource.Id.listView1);
            items = new List<Car> 
            { 
                new Car {Manufacturer="Ford", Model = "Focus", KW =100 },
                new Car {Manufacturer="Volkswagen", Model = "Passat", KW =45 },
                new Car {Manufacturer="BMW", Model = "X5", KW =100 },
                new Car {Manufacturer="Audi", Model = "A7", KW =3 },
                new Car {Manufacturer="BMW", Model = "X7", KW =787 },
                new Car {Manufacturer="BMW", Model = "6", KW =55 },
                new Car {Manufacturer="Ford2", Model = "Focus3", KW =5 },
                new Car {Manufacturer="Ford3", Model = "Focus6", KW =77 },
                new Car {Manufacturer="Ford4", Model = "Focus8", KW =99 },
                new Car {Manufacturer="Ford", Model = "Focus", KW =100 },
                new Car {Manufacturer="Volkswagen", Model = "Passat", KW =45 },
                new Car {Manufacturer="BMW", Model = "X5", KW =100 },
                new Car {Manufacturer="Audi", Model = "A7", KW =3 },
                new Car {Manufacturer="BMW", Model = "X7", KW =787 },
                new Car {Manufacturer="BMW", Model = "6", KW =55 },
                new Car {Manufacturer="Ford2", Model = "Focus3", KW =5 },
                new Car {Manufacturer="Ford3", Model = "Focus6", KW =77 },
                new Car {Manufacturer="Ford4", Model = "Focus8", KW =99 }
            };

            listView.Adapter = new CarAdapter(this, items); //tuli kaasa anda activity-> this, disain, ja see asjade list ehk items


            // Create your application here
        }
    }
}