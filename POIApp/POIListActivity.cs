using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using POIApp.Services;

namespace POIApp
{
    [Activity(Label = "POIApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class POIListActivity : AppCompatActivity
    {
        private ListView poiListView;
        private ProgressBar progressBar;
        private List<PointOfInterest> poiListData;
        private POIListViewAdapter poiListAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.POIList);

            poiListView = FindViewById<ListView>(Resource.Id.poiListView);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            DownloadPoiListAsync();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.POIListViewMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public async void DownloadPoiListAsync()
        {
            progressBar.Visibility = ViewStates.Visible;
            POIService service = new POIService();
            poiListData = await service.GetPOIListAsync();
            progressBar.Visibility = ViewStates.Gone;

            poiListAdapter = new POIListViewAdapter(this,poiListData);
            poiListView.Adapter = poiListAdapter;

        }

        

         
    }
}
