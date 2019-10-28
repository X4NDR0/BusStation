using System.Collections.Generic;

namespace BusStationSystem.Models
{
    /// <summary>
    /// Class for representing the carrier model
    /// </summary>
    public class TransportationCompany
    {
        /// <summary>
        /// Contructor of the class transportation company
        /// </summary>
        public TransportationCompany()
        {
            ListOfBuses = new List<Autobus>();
        }

        /// <summary>
        /// Property representing the autobus
        /// </summary>
        public List<Autobus> ListOfBuses;

        /// <summary>
        /// Property representing the carrier unique ID
        /// </summary>
        public int TransportationCompanyID;

        /// <summary>
        /// Property representing the transportation company name
        /// </summary>
        public string TransportationCompanyName;

        /// <summary>
        /// Property representing the transportation company place
        /// </summary>
        public string TransportationCompanyLocation;
    }
}
