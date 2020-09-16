using GoogleMaps.LocationServices.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoogleMaps.LocationServices.Api.Controllers
{
    public class GoogleMapController : ApiController
    {
        [HttpPost]
        [Route("api/GoogleMap/GetLatLongFromAddress")]
        public IHttpActionResult GetLatLongFromAddress(List<AddressData> addresses)
        {
            List<MapCreds> _mapCreds = new List<MapCreds>();
            var gls = new GoogleLocationService();
            foreach (var address in addresses.ToArray())
            {
                var latlong = gls.GetLatLongFromAddress(address);
                _mapCreds.Add(new MapCreds { latitude = latlong.Latitude, longitude = latlong.Longitude });
            }
            return Ok(_mapCreds);
        }


        [HttpPost]
        [Route("api/GoogleMap/GetAddressFromLatLong")]
        public IHttpActionResult GetAddressFromLatLong(MapCreds mapCreds)
        {
            var gls = new GoogleLocationService();
            Region address = gls.GetRegionFromLatLong(mapCreds.latitude, mapCreds.longitude);
            return Ok(address);
        }

    }
}
