using System;

namespace GoogleMaps.LocationServices.Api.Models
{
    public class MapCreds
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }


    public class AddressData
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }


    }

}    