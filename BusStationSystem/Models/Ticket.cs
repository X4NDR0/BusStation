using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationSystem.Models
{
    /// <summary>
    /// Class representing the ticket
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public Ticket()
        {
            TransportationCompany = new TransportationCompany();
            Autobus = new Autobus();
            BusStationStarting = new BusStation();
            BusStationArrival = new BusStation();
        }

        /// <summary>
        /// Property representing of the ticked id
        /// </summary>
        public int TicketId;

        /// <summary>
        /// Property representing transportation company
        /// </summary>
        public TransportationCompany TransportationCompany;

        /// <summary>
        /// Property representing autobus
        /// </summary>
        public Autobus Autobus;

        /// <summary>
        /// Property representing the bus station starting
        /// </summary>
        public BusStation BusStationStarting;

        /// <summary>
        /// Property representing the bus station arrival
        /// </summary>
        public BusStation BusStationArrival;
    }
}
