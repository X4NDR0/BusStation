using System;

namespace BusStationSystem.Utilies
{
    /// <summary>
    /// Representing Helper Class
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Method that checks for int validaty
        /// </summary>
        public static int CheckIntInput()
        {
            int number;
            while (Int32.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.Write("Sorry,wrong input try again:");
            }
            return number;
        }
        /// <summary>
        /// Method that checks for string validity
        /// </summary>
        public static string CheckStringInput()
        {
            string input = "";
            while (input == null || input.Equals(""))
            {
                input = Console.ReadLine();
            }
            return input;
        }

        /// <summary>
        /// Method that checks for date time validity
        /// </summary>
        public static DateTime CheckDateTimeInput()
        {
            DateTime dt = new DateTime();

            while (DateTime.TryParse(Console.ReadLine(),out dt) == false)
            {
                Console.Write("Sorry,wrong input format try again:");
            }
            return dt;
        }

    }
}
