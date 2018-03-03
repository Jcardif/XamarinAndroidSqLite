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

namespace XamarinAndroidSQLite.Custom_Events
{
   public class OnSubmitAeroPlaneId : EventArgs
    {
        public int Id { get; set; }

        public OnSubmitAeroPlaneId(int Id)
        {
            this.Id = Id;
        }
    }
}