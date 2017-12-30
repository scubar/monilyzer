using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Monilyzer.Model.Enums;

namespace Monilyzer.Model
{
    public class Node
    {
        [Key]
        public Guid Guid { get; set; }

        public string ExternalId { get; set; }

        /// <summary>
        /// Node Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Node Status.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Node Packet Loss during last Poll.
        /// </summary>
        public decimal PacketLoss { get; set; }

        /// <summary>
        /// Node Response Time during last Poll.
        /// </summary>
        public decimal ResponseTime { get; set; }

        /// <summary>
        /// Node Polling IP Address.
        /// </summary>
        public IPAddress IPAddress { get; set; }

        /// <summary>
        /// Node Location.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Node Customer.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Node Interfaces.
        /// </summary>
        public virtual List<Interface> Interfaces { get; set; }

        /// <summary>
        /// Node Volumes.
        /// </summary>
        public virtual List<Volume> Volumes { get; set; }

        public void Update(Node node)
        {
            if (node != null)
            {
                Name = node.Name;
                IPAddress = node.IPAddress;

                LastUpdated = DateTime.UtcNow;
            }
        }

        public void PollingUpdate(Node node){
            if (node != null)
            {
                Status = node.Status;
                PacketLoss = node.PacketLoss;
                ResponseTime = node.ResponseTime;

                LastPolled = DateTime.UtcNow;
            }
        }

        public DateTime LastUpdated { get; set; } = DateTimeHelper.DefaultDateTime;

        public DateTime LastPolled { get; set; } = DateTimeHelper.DefaultDateTime;
    }
}
