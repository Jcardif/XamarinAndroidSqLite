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
  public class SubmitPlaneIdDialogFragment : DialogFragment
  {
      private EditText _idEdtTxt;
      private Button submitBtn;
      public event EventHandler<OnSubmitAeroPlaneId> OnSubmitPlaneId;

      public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
      {
          base.OnCreateView(inflater, container, savedInstanceState);
          var view = inflater.Inflate(Resource.Layout.GetPlaneById, container, false);
          _idEdtTxt = view.FindViewById<EditText>(Resource.Id.idEdtTxt);
          submitBtn = view.FindViewById<Button>(Resource.Id.getAeroBtn);

          submitBtn.Click+= delegate
          {
              OnSubmitPlaneId.Invoke(this, new OnSubmitAeroPlaneId(Convert.ToInt32(_idEdtTxt.Text)));
              Dismiss();
          };
          return view;
      }
  }
}