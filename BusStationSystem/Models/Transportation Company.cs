using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationSystem.Models
{
    /// <summary>
    /// Class for representing the carrier model
    /// </summary>
    public class TransportationCompany
    {
        /// <summary>
        /// Contructor of the class carrier
        /// </summary>
        public TransportationCompany()
        {
            Autobus = new Autobus();
        }

        /// <summary>
        /// Property representing the autobus
        /// </summary>
        public Autobus Autobus;

        /// <summary>
        /// Property representing the carrier unique ID
        /// </summary>
        public int TransportationCompanyID;

        /// <summary>
        /// Property representing the carrier name
        /// </summary>
        public string TransportationCompanyName;

        /// <summary>
        /// Property representing the carrier place
        /// </summary>
        public string TransportationCompanyPlace;
    }
}
