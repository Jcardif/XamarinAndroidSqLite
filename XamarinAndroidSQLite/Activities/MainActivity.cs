using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using XamarinAndroidSQLite.Custom_Events;
using XamarinAndroidSQLite.Dialog_Fragments;
using XamarinAndroidSQLite.ORM;

namespace XamarinAndroidSQLite.Activities
{
    [Activity(Label = "XamarinAndroidSQLite", MainLauncher = true)]
    public class MainActivity : Activity, View.IOnClickListener
    {
        private Button createdb, createtbl, inserdata, getData, getDataById, updateBtn, deleteData;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Home);
            createdb = FindViewById<Button>(Resource.Id.createdbBtn);
            createtbl = FindViewById<Button>(Resource.Id.createtableBtn);
            inserdata = FindViewById<Button>(Resource.Id.insertRecordBtn);
            getData = FindViewById<Button>(Resource.Id.getdatabtn);
            getDataById = FindViewById<Button>(Resource.Id.getDataByid);
            updateBtn = FindViewById<Button>(Resource.Id.updatedataBtn);
            deleteData = FindViewById<Button>(Resource.Id.deleteDataBtn);

            createdb.SetOnClickListener(this);
            createtbl.SetOnClickListener(this);
            inserdata.SetOnClickListener(this);
            getData.SetOnClickListener(this);
            getDataById.SetOnClickListener(this);
            updateBtn.SetOnClickListener(this);
            deleteData.SetOnClickListener(this);
        }
        public void OnClick(View v)
        {
            switch (v.Id)
            {
                case Resource.Id.createdbBtn:
                    Toast.MakeText(this, new DatabaseRepository().CreateDatabase(), ToastLength.Short).Show();
                    break;
                case Resource.Id.createtableBtn:
                    Toast.MakeText(this,new DatabaseRepository().CreateTable(),ToastLength.Short).Show();
                    break;
                case Resource.Id.insertRecordBtn:
                    var transaction = FragmentManager.BeginTransaction();
                    var submitAeroplane = new SubmitAeroplaneDialogFragment();
                    submitAeroplane.Show(transaction, "tag");
                    submitAeroplane.OnSubmitAeroplane += SubmitAeroplane_OnSubmitAeroplane;
                    break;
                case Resource.Id.getdatabtn:
                    Toast.MakeText(this,$"{new DatabaseRepository().GetAllRecords().Count}", ToastLength.Short).Show();
                    break;
                case Resource.Id.getDataByid:
                    var transaction1 = FragmentManager.BeginTransaction();
                    var submitPlaneId = new SubmitPlaneIdDialogFragment();
                    submitPlaneId.Show(transaction1, "tag");
                    submitPlaneId.OnSubmitPlaneId += SubmitPlaneId_OnSubmitPlaneId;
                    break;
            }
        }

        private void SubmitPlaneId_OnSubmitPlaneId(object sender, OnSubmitAeroPlaneId e)
        {
            Toast.MakeText(this,new DatabaseRepository().GetSpecifiAeroplane(e.Id).Name, ToastLength.Short).Show();
        }

        private void SubmitAeroplane_OnSubmitAeroplane(object sender, Custom_Events.OnSubmitAeroplaneEventArgs e)
        {
            Toast.MakeText(this, new DatabaseRepository().InserRecord(e.Name), ToastLength.Short).Show();
        }
    }
}

