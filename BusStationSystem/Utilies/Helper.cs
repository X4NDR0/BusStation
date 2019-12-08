using System;

namespace BusStationSystem.Utilies
{
    /// <summary>
    /// Representing Helper Class
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Method representing checking input for numbers
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
        /// Method representing string input for string
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

    }
}
