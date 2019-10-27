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
        /// Property representing the transportation company name
        /// </summary>
        public string TransportationCompanyName;

        /// <summary>
        /// Property representing the transportation company place
        /// </summary>
        public string TransportationCompanyPlace;
    }
}
