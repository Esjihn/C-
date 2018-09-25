using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListApp.Models
{
    class GeoLocationModel
    {
        public string Id { get; set; }
        public DateTime DateTime { get; set; }
        public string GeoLocation { get; set; }
        public string PopulateGeoFromCalData { get; set; }
        public GeoLocationModel GeolocationModel { get; set; }


    }
}
