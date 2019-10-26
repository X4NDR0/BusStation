using System;
namespace BusStationSystem.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            BusStationService bs = new BusStationService();
            bs.Initialize();
        }
    }
}
