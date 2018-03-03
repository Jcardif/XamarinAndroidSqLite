using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinAndroidSQLite.Activities
{
    [Activity(Label = "GetAllPlanes")]
    public class GetAllPlanesActivity : Activity
    {
        private ListView _allPlanesLstView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AllAeroplanes);
            _allPlanesLstView = FindViewById<ListView>(Resource.Id.aerplanesList);

        }
    }
}