using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Monilyzer.Data;
using Monilyzer.Model;

namespace Monilyzer.API.Services
{
    public class LocationService
    { 
        MonilyzerContext MonilyzerContext { get; set; }

        public LocationService(MonilyzerContext monilyzerContext)
        {
            MonilyzerContext = monilyzerContext;
        }

        public Location GetLocation(Guid guid)
        {
            var location = MonilyzerContext.Locations.FirstOrDefault(l => l.Guid == guid);

            if (location == null) throw new NullReferenceException();

            return location;
        }

        public IEnumerable<Location> GetLocations()
        {
            return MonilyzerContext.Locations.ToList();
        }

        public Location CreateLocation(Location location)
        {
            MonilyzerContext.Locations.Add(location);

            MonilyzerContext.SaveChanges();

            return location;
        }

        public Location UpdateLocation(Guid guid, Location location)
        {
            var Location = GetLocation(guid);

            Location.Update(location);

            MonilyzerContext.SaveChanges();

            return Location;
        }

        public void DeleteLocation(Guid guid)
        {
            var Location = GetLocation(guid);

            foreach(var node in Location.Nodes)
            {
                node.Location = null;
            }

            MonilyzerContext.Locations.Remove(Location);

            MonilyzerContext.SaveChanges();
        }
    }
}
