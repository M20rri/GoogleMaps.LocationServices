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
            List<GooglemapResponse> _mapCreds = new List<GooglemapResponse>();
            var gls = new GoogleLocationService();
            foreach (var address in addresses.ToArray().Select((value, i) => (value, i)))
            {
                var latlong = gls.GetLatLongFromAddress(address.value);
                _mapCreds.Add(new GooglemapResponse {Id = address.i+1 ,  latitude = latlong.Latitude, longitude = latlong.Longitude , Name = address.value.Address });
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
