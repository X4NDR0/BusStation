namespace BusStationSystem.Models
{
    /// <summary>
    /// Representing class the autobus model
    /// </summary>
    public class Autobus
    {
        /// <summary>
        /// Class constructor of autobus
        /// </summary>
        public Autobus()
        {
            AutobusType = new AutobusType();
        }

        /// <summary>
        /// Property representing the autobus type
        /// </summary>
        public AutobusType AutobusType;

        /// <summary>
        /// Property representing the autobus registration number
        /// </summary>
        public int AutobusRegNumber;

    }
}
