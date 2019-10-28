namespace BusStationSystem.Models
{
    /// <summary>
    /// Representing class of the bus station
    /// </summary>
    public class BusStation
    {
        /// <summary>
        /// Constructor of the class
        /// </summary>
        public BusStation()
        {
            Peron = new Peron();
        }

        /// <summary>
        /// Property represeting ID of the bus station
        /// </summary>
        public int BusStationID;

        /// <summary>
        /// Property represeting the place
        /// </summary>
        public string Location;

        /// <summary>
        /// Object representing of the peron
        /// </summary>
        public Peron Peron;
    }
}
