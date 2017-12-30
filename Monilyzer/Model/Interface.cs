using System;
using System.ComponentModel.DataAnnotations;
using Monilyzer.Model.Enums;

namespace Monilyzer.Model
{
    public class Interface
    {
        [Key]
        public Guid Guid { get; set; }

        public string ExternalId { get; set; }

        /// <summary>
        /// Interface Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Interface speed in Megabits per Second
        /// </summary>
        public decimal Speed { get; set; }

        /// <summary>
        /// Interface Duplex (Half, Full, Auto)
        /// </summary>
        public Duplex Duplex { get; set; }

        /// <summary>
        /// Transmit Utilization.
        /// </summary>
        public decimal TransmitUtilization { get; set; }

        /// <summary>
        /// Transmit Utilization Percentage.
        /// </summary>
        public decimal TransmitUtilizationPercentage => (TransmitUtilization / TransmitBandwidth) * 100;

        /// <summary>
        /// Transmit Bandwidth of the Interface.
        /// </summary>
        public decimal TransmitBandwidth { get; set; }

        /// <summary>
        /// Utilized Receive Bandwidth.
        /// </summary>
        public decimal RecieveUtilization { get; set; }

        /// <summary>
        /// Receive Utilization Percentage.
        /// </summary>
        public decimal RecieveUtilizationPercentage => (RecieveUtilization / RecieveBandwidth) * 100;

        /// <summary>
        /// Available Recieve Bandwidth.
        /// </summary>
        public decimal RecieveBandwidth { get; set; }

        //TODO: Error and Packet Counters

        public void Update(Interface uinterface)
        {
            if (uinterface != null)
            {
                Name = uinterface.Name;
                Speed = uinterface.Speed;
                TransmitBandwidth = uinterface.TransmitBandwidth;
                RecieveBandwidth = uinterface.RecieveBandwidth;

                LastUpdated = DateTime.UtcNow;
            }
        }

        public void PollingUpdate(Interface uinterface)
        {
            if (uinterface != null)
            {
                Duplex = uinterface.Duplex;
                TransmitUtilization = uinterface.TransmitUtilization;
                RecieveUtilization = uinterface.RecieveUtilization;
                //TODO: Update Error and Packet Counters

                LastPolled = DateTime.UtcNow;
            }    
        }

        public DateTime LastUpdated { get; set; } = DateTimeHelper.DefaultDateTime;

        public DateTime LastPolled { get; set; } = DateTimeHelper.DefaultDateTime;
    }
}
