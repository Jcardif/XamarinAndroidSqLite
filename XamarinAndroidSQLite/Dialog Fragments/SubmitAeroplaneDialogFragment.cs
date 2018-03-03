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
using XamarinAndroidSQLite.Custom_Events;

namespace XamarinAndroidSQLite.Dialog_Fragments
{
    public class SubmitAeroplaneDialogFragment : DialogFragment
    {
        private EditText _nameEdtTxt;
        private Button _submitBtn;
        public event EventHandler<OnSubmitAeroplaneEventArgs> OnSubmitAeroplane;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.AddRecord, container, false);
            _nameEdtTxt = view.FindViewById<EditText>(Resource.Id.nameEdtTxt);
            _submitBtn = view.FindViewById<Button>(Resource.Id.addAeroplane);

            _submitBtn.Click += (s, e) =>
            {
               OnSubmitAeroplane.Invoke(this, new OnSubmitAeroplaneEventArgs(_nameEdtTxt.Text));
                Dismiss();
            };
            return view;
        }

      
    }
}