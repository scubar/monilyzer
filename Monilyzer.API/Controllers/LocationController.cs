using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monilyzer.API.Services;
using Monilyzer.Data;
using Monilyzer.Model;

namespace Monilyzer.API.Controllers
{
    /// <summary>
    /// Controller for interacting with Location objects.
    /// </summary>
    [Route("api/v1/locations")]
    public class LocationController : Controller
    {
        public LocationController(MonilyzerContext monilyzerContext)
        {
            MonilyzerContext = monilyzerContext;
        }

        MonilyzerContext MonilyzerContext { get; set; }

        // GET: api/v1/locations
        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return new LocationService(MonilyzerContext).GetLocations();
        }

        // GET api/v1/locations/<Guid>
        [HttpGet("{guid}")]
        public Location Get(Guid guid)
        {
            return new LocationService(MonilyzerContext).GetLocation(guid); 
        }

        // POST api/v1/locations
        [HttpPost]
        public Location Post([FromBody]Location location)
        {
            return new LocationService(MonilyzerContext).CreateLocation(location); 
        }

        // PUT api/v1/locations/<Guid>
        [HttpPut("{guid}")]
        public Location Put(Guid guid, [FromBody]Location location)
        {
            return new LocationService(MonilyzerContext).UpdateLocation(guid, location); 
        }

        // DELETE api/v1/locations/<Guid>
        [HttpDelete("{guid}")]
        public void Delete(Guid guid)
        {
            new LocationService(MonilyzerContext).DeleteLocation(guid); 
        }
    }
}
