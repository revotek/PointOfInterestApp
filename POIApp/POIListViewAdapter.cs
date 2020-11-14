using Android.App;
using Android.Views;
using Android.Widget;
using POIApp.UrlImageViewHelper;
using System;
using System.Collections.Generic;

namespace POIApp
{
    public class POIListViewAdapter : BaseAdapter<PointOfInterest>
    {
        private readonly Activity context;
        private List<PointOfInterest> poiListData;
        public POIListViewAdapter(Activity _context, List<PointOfInterest> _poiListData) : base()
        {
            this.context = _context;
            this.poiListData = _poiListData;
        }

        public override int Count => poiListData.Count;

        public override PointOfInterest this[int index] => poiListData[index];

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.POIListItem, null, false);
            }

            //Populate Name textview widget
            PointOfInterest poi = this[position];
            view.FindViewById<TextView>(Resource.Id.nameTextView).Text = poi.Name;

            //Populate Address textview widget
            if (String.IsNullOrEmpty(poi.Address))
            {
                view.FindViewById<TextView>(Resource.Id.addrTextView).Visibility = ViewStates.Gone;
            }
            else
            {
                view.FindViewById<TextView>(Resource.Id.addrTextView).Text = poi.Address;
            }

            //Populate ImageView widget
            var imageView = view.FindViewById<ImageView>(Resource.Id.poiImageView);
            if (!String.IsNullOrEmpty(poi.Address))
            {
                imageView.SetUrlDrawable(poi.Image, Resource.Drawable.ic_placeholder);
            }

            return view;
        }


    }
}