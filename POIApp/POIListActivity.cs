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
            poiListView.ItemClick += POIClicked;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.POIListViewMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public async void DownloadPoiListAsync()
        {
            POIService service = new POIService();
            if (!service.isConnected(this))
            {
                Toast toast = Toast.MakeText(this, "Not connected to internet. Please check your device network settings.", ToastLength.Short);
                toast.Show();
            }
            else
            {
                progressBar.Visibility = ViewStates.Visible;

                poiListData = await service.GetPOIListAsync();
                progressBar.Visibility = ViewStates.Gone;

                poiListAdapter = new POIListViewAdapter(this, poiListData);
                poiListView.Adapter = poiListAdapter;
            }


        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.actionNew:
                    return true;
                case Resource.Id.actionRefresh:
                    DownloadPoiListAsync();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }

        }

        protected void POIClicked(object sender, ListView.ItemClickEventArgs e)
        {
            PointOfInterest poi = poiListData[(int)e.Id];
            Console.Out.WriteLine("POI Clicked: Name is {0}", poi.Name);
        }
    }
}
