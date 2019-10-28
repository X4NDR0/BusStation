using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationSystem.Models
{
    /// <summary>
    /// ????????
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// ??????
        /// </summary>
        public Ticket()
        {
            TransportationCompany = new TransportationCompany();
            BusStationStarting = new BusStation();
            BusStationArrival = new BusStation();
        }

        /// <summary>
        /// ??????
        /// </summary>
        public int TicketId;

        /// <summary>
        /// ????
        /// </summary>
        public TransportationCompany TransportationCompany;

        /// <summary>
        /// ??????
        /// </summary>
        public BusStation BusStationStarting;

        /// <summary>
        /// ???
        /// </summary>
        public BusStation BusStationArrival;
    }
}
