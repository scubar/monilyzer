using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monilyzer.Model
{
    public class Location
    {
        [Key]
        public Guid Guid { get; set; }

        /// <summary>
        /// Location Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Location City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Location State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Location Country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Location Latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = Math.Round(value, 5); } // 1.1M Accuracy
        }

        private double _latitude;

        /// <summary>
        /// Location Longitude.
        /// </summary>
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = Math.Round(value, 5); } // 1.1M Accuracy
        }

        private double _longitude;

        /// <summary>
        /// Location Nodes.
        /// </summary>
        public virtual List<Node> Nodes { get; set; } = new List<Node>();
        public List<ActiveAlert> ActiveAlerts { get; set; } = new List<ActiveAlert>();

        public Guid CustomerGuid { get; set; }

        public void Update(Location location)
        {
            if (!string.IsNullOrEmpty(location.Name))
            {
                Name = location.Name;
                City = location.City;
                State = location.State;
                Country = location.Country;
                Latitude = location.Latitude;
                Longitude = location.Longitude;
            }         
        }

        public DateTime LastUpdated { get; set; } = DateTimeHelper.DefaultDateTime;
        public DateTime LastPolled { get; set; } = DateTimeHelper.DefaultDateTime;
    }
}
