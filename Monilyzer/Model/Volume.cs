using System;
using System.ComponentModel.DataAnnotations;

namespace Monilyzer.Model
{
    public class Volume
    {
        [Key]
        public Guid Guid { get; set; }

        public string ExternalId { get; set; }

        /// <summary>
        /// Volume Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Volume Capacity.
        /// </summary>
        public decimal Capacity { get; set;}

        /// <summary>
        /// Volume Capacity Utilization
        /// </summary>
        public decimal CapacityUtilization { get; set; }

        /// <summary>
        /// Volume Capacity Utilization Percentage.
        /// </summary>
        public decimal CapacityUtilizationPercentage => (Capacity / CapacityUtilization) * 100;

        public void Update(Volume volume)
        {
            if (volume != null)
            {
                Name = volume.Name;

                LastUpdated = DateTime.UtcNow;
            }    
        }

        public void PollingUpdate(Volume volume)
        {
            if (volume != null)
            {              
                Capacity = volume.Capacity;
                CapacityUtilization = volume.CapacityUtilization;

                LastPolled = DateTime.UtcNow;
            }
        }

        public DateTime LastUpdated { get; set; } = DateTimeHelper.DefaultDateTime;

        public DateTime LastPolled { get; set; } = DateTimeHelper.DefaultDateTime;
    }
}
