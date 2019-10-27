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
        /// Object representing of the peron
        /// </summary>
        Peron Peron;

        /// <summary>
        /// Property represeting the place
        /// </summary>
        public string Place;

        /// <summary>
        /// Property represeting ID of the bus station
        /// </summary>
        public int BusStationID;

    }
}
