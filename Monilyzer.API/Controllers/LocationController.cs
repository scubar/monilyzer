using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monilyzer.API.Data;
using Monilyzer.API.Services;
using Monilyzer.Model;

namespace Monilyzer.API.Controllers
{
    /// <summary>
    /// Controller for interacting with Location objects.
    /// </summary>
    [Authorize]
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
            return new LocationRepository(MonilyzerContext).GetLocations();
        }

        // GET api/v1/locations/<Guid>
        [HttpGet("{guid}")]
        public Location Get(Guid guid)
        {
            return new LocationRepository(MonilyzerContext).GetLocation(guid); 
        }

        // POST api/v1/locations
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public Location Post([FromBody]Location location)
        {
            return new LocationRepository(MonilyzerContext).CreateLocation(location); 
        }

        // PUT api/v1/locations/<Guid>
        [Authorize(Roles = "Administrator")]
        [HttpPut("{guid}")]
        public Location Put(Guid guid, [FromBody]Location location)
        {
            return new LocationRepository(MonilyzerContext).UpdateLocation(guid, location); 
        }

        // DELETE api/v1/locations/<Guid>
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{guid}")]
        public void Delete(Guid guid)
        {
            new LocationRepository(MonilyzerContext).DeleteLocation(guid); 
        }
    }
}
