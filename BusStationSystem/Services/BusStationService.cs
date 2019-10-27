using BusStationSystem.Enums;
using BusStationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusStationSystem.Services
{
    /// <summary>
    /// Service used to manipulate the bus station data.
    /// </summary>
    public class BusStationService
    {
        private static List<TransportationCompany> transportationCompanyList = new List<TransportationCompany>();
        private static List<Autobus> autobusList = new List<Autobus>();
        Menu options;

        /// <summary>
        /// Used to run service
        /// </summary>
        public void Initialize()
        {
            LoadData();
            do
            {
                MenuText();
                Enum.TryParse(Console.ReadLine(), out options);

                switch (options)
                {
                    case Menu.carrierMenu:
                        Console.Clear();
                        MenuCarrier();
                        break;

                    case Menu.exit:
                        break;

                    default:
                        Console.WriteLine("Pogresan unos!");
                        break;
                }
            } while (options != Menu.exit);
        }

        private void MenuText()
        {
            Console.WriteLine("1.Carrier menu");
            Console.WriteLine("0.Exit");
            Console.Write("Unos:");
        }

        private void MenuTextCarrier()
        {
            Console.WriteLine("1.Write all carriers");
            Console.WriteLine("2.Edit carrier");
            Console.WriteLine("3.Remove carrier");
            Console.WriteLine("4.Add carrier");
            Console.Write("Unos:");
        }

        private void MenuCarrier()
        {
            MenuTextCarrier();
            Int32.TryParse(Console.ReadLine(), out int id);

            switch (id)
            {
                case 1:
                    Console.Clear();
                    WriteAllTransportaionCompany();
                    break;

                case 2:
                    Console.Clear();
                    EditTransportaionCompany();
                    break;

                case 3:
                    Console.Clear();
                    RemoveTransportaionCompany();
                    break;

                case 4:
                    Console.Clear();
                    AddTransportaionCompany();
                    break;

                default:
                    break;
            }
        }

        private void WriteAllTransportaionCompany()
        {
            foreach (TransportationCompany transportationCompany in transportationCompanyList)
            {
                Console.WriteLine(transportationCompany.TransportationCompanyID + " " + transportationCompany.TransportationCompanyName + " " + transportationCompany.TransportationCompanyPlace + "\nAutobus Registration Number:" + transportationCompany.Autobus.AutobusRegNumber + "\nAutobus Type:" + transportationCompany.Autobus.AutobusType.TypeName + "\n");
            }
        }

        private void EditTransportaionCompany()
        {
            TipAutobusa tipa;
            Console.Write("Please enter carrier ID:");
            Int32.TryParse(Console.ReadLine(), out int selectID);

            TransportationCompany CheckID = transportationCompanyList.Where(x => x.TransportationCompanyID == selectID).First();

            if (CheckID != null)
            {
                Console.Write("Enter new ID of the carrier:");
                Int32.TryParse(Console.ReadLine(), out int newID);

                Console.Write("Enter new name and lastname of the carrier:");
                string newName = Console.ReadLine();

                Console.Write("Enter new place:");
                string newPlace = Console.ReadLine();

                WriteAllAutobuses();
                Console.Write("Enter ID of the autobus:");
                Int32.TryParse(Console.ReadLine(), out int autobusID);

                Console.WriteLine("Enter type of the autobus:");
                Console.WriteLine("1.Jednospratni");
                Console.WriteLine("2.Dvospratni");
                Console.WriteLine("3.Mini bus");
                Console.Write("Unos:");

                if (Enum.TryParse("Jednospratni", out tipa) == false)
                {

                }
                AutobusType autobusTypeEdit = new AutobusType { AutobusID = autobusID, TypeName = tipa.ToString() };
                Autobus autobusEdit = new Autobus { AutobusRegNumber = autobusID, AutobusType = autobusTypeEdit };
                TransportationCompany transportationCompanyEdit = new TransportationCompany { TransportationCompanyID = newID, TransportationCompanyName = newName, Autobus = autobusEdit, TransportationCompanyPlace = newPlace };
                int indexFindedTC = transportationCompanyList.IndexOf(CheckID);
                transportationCompanyList[indexFindedTC] = transportationCompanyEdit;
            }
            else
            {
                Console.WriteLine("This ID does not exits!");
            }
        }

        private void RemoveTransportaionCompany()
        {
            Console.Write("Enter the ID of the TC you want to delete:");
            Int32.TryParse(Console.ReadLine(),out int deleteID);

            TransportationCompany DeleteID = transportationCompanyList.Where(x => x.TransportationCompanyID == deleteID).First();

            if (DeleteID != null)
            {
                transportationCompanyList.Remove(DeleteID);
                Console.WriteLine("You successfully deleted transportation company");
            }else
            {
                Console.WriteLine("That ID does not exits!");
            }
        }

        private void AddTransportaionCompany()
        {
            Console.Write("Enter a new ID:");
            Int32.TryParse(Console.ReadLine(),out int addID);

            TransportationCompany addTransportationCompany = transportationCompanyList.Where(x => x.TransportationCompanyID == addID).First();

            if (addTransportationCompany != null)
            {
                Console.WriteLine("Sorry,but that ID alredy used!");
            }
            else
            {
                Console.WriteLine("Success :D");
            }

        }

        private void LoadData()
        {
            AutobusType autobusType1 = new AutobusType { AutobusID = 28771, TypeName = "Jednospartni" };
            AutobusType autobusType2 = new AutobusType { AutobusID = 62825, TypeName = "Mini bus" };

            Autobus autobus1 = new Autobus { AutobusRegNumber = 382729172, AutobusType = autobusType1 };
            Autobus autobus2 = new Autobus { AutobusRegNumber = 826382667, AutobusType = autobusType2 };

            TransportationCompany tc1 = new TransportationCompany { TransportationCompanyID = 2727, TransportationCompanyName = "Nikola Petrovic", TransportationCompanyPlace = "Kragujevac", Autobus = autobus1 };
            TransportationCompany tc2 = new TransportationCompany { TransportationCompanyID = 2638, TransportationCompanyName = "Petar Mitrovic", TransportationCompanyPlace = "Subotica", Autobus = autobus2 };

            autobusList.Add(autobus1);
            autobusList.Add(autobus2);

            transportationCompanyList.Add(tc1);
            transportationCompanyList.Add(tc2);
        }

        private void WriteAllAutobuses()
        {
            foreach (Autobus autobus in autobusList)
            {
                Console.WriteLine(autobus.AutobusRegNumber + " " + autobus.AutobusType.TypeName);
            }
        }

        private enum TipAutobusa
        {
            jednospratni = 1,
            dvospratni = 2,
            minibus = 3
        }
    }
}