
using Android.Content;
using Android.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace POIApp.Services
{
    public class POIService
    {
        private const string GET_POIS = "http://192.168.0.4:45457/api/poi";
        private readonly List<PointOfInterest> poiListData = new List<PointOfInterest>();

        public async Task<List<PointOfInterest>> GetPOIListAsync()
        {
            HttpClient httpClient = new HttpClient(new Xamarin.Android.Net.AndroidClientHandler());
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.GetAsync(GET_POIS);



            if (response != null || response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<List<PointOfInterest>>(content);
                 
                Console.Out.WriteLine("Response Body; \r\n {0}", results);
                return results;
            }
            else
            {
                Console.Out.WriteLine("Failed to fetch data. Try again later!");
                return null;
            }
        }

        public bool isConnected(Context activity){ 
            var connManager = (ConnectivityManager)activity.GetSystemService(Context.ConnectivityService);
            var activeConnection = connManager.ActiveNetworkInfo;
            return (null != activeConnection && activeConnection.IsConnected);
            }
    }
}