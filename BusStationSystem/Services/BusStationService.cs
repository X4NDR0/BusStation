using BusStationSystem.Enums;
using BusStationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusStationSystem.Services
{
    public class BusStationService
    {
        public static List<TransportationCompany> transportationCompanyList = new List<TransportationCompany>();
        public static List<Autobus> autobusList = new List<Autobus>();
        Menu options;

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
                    WriteAllCarriers();
                    break;

                case 2:
                    Console.Clear();
                    EditCarrier();
                    break;

                case 3:

                    break;

                case 4:

                    break;

                default:
                    break;
            }
        }


        private void WriteAllCarriers()
        {
            foreach (TransportationCompany transportationCompany in transportationCompanyList)
            {
                Console.WriteLine(transportationCompany.TransportationCompanyID + " " + transportationCompany.TransportationCompanyName + " " + transportationCompany.TransportationCompanyPlace + "\nAutobus Registration Number:" + transportationCompany.Autobus.AutobusRegNumber + "\nAutobus Type:" + transportationCompany.Autobus.AutobusType.TypeName + "\n");
            }
        }

        private void EditCarrier()
        {
            Console.WriteLine("Please enter carrier ID:");
            Int32.TryParse(Console.ReadLine(),out int selectID);

            TransportationCompany CheckID = transportationCompanyList.Where(x => x.TransportationCompanyID == selectID).First();

            if (CheckID != null)
            {
                Console.WriteLine("Enter new ID of the carrier:");
                Int32.TryParse(Console.ReadLine(),out int newID);

                Console.WriteLine("Enter new name and lastname of the carrier:");
                string newName = Console.ReadLine();

                Console.WriteLine("Enter new place:");
                string newPlace = Console.ReadLine();

                WriteAllAutobuses();
                Console.Write("Enter ID of the autobus:");
                Int32.TryParse(Console.ReadLine(),out int autobusID);


                Console.Write("Enter type of the autobus:");
                string type = Console.ReadLine();

                AutobusType autobusTypeEdit = new AutobusType {AutobusID = autobusID,TypeName = type};
                Autobus autobusEdit = new Autobus { AutobusRegNumber = autobusID,AutobusType = autobusTypeEdit};

                TransportationCompany transportationCompanyEdit = new TransportationCompany {TransportationCompanyID = newID,TransportationCompanyName = newName,Autobus = autobusEdit,TransportationCompanyPlace = newPlace};

                int indexFindedTC = transportationCompanyList.IndexOf(CheckID);

                transportationCompanyList[indexFindedTC] = transportationCompanyEdit;

            }else
            {
                Console.WriteLine("This ID does not exits!");
            }
        }


        private void LoadData()
        {
            AutobusType autobusType1 = new AutobusType { AutobusID = 28771, TypeName = "Jednospartni" };
            AutobusType autobusType2 = new AutobusType { AutobusID = 62825, TypeName = "Mini bus" };

            Autobus autobus1 = new Autobus { AutobusRegNumber = 382729172,AutobusType = autobusType1};
            Autobus autobus2 = new Autobus { AutobusRegNumber = 826382667,AutobusType = autobusType2};

            TransportationCompany tc1 = new TransportationCompany{ TransportationCompanyID = 2727, TransportationCompanyName = "Nikola Petrovic", TransportationCompanyPlace = "Kragujevac", Autobus = autobus1 };
            TransportationCompany tc2 = new TransportationCompany { TransportationCompanyID = 2638, TransportationCompanyName = "Petar Mitrovic", TransportationCompanyPlace = "Subotica", Autobus = autobus2 };

            autobusList.Add(autobus1);
            autobusList.Add(autobus2);

            transportationCompanyList.Add(tc1);
            transportationCompanyList.Add(tc2);
        }

        public void WriteAllAutobuses()
        {
            foreach (Autobus autobus in autobusList)
            {
                Console.WriteLine(autobus.AutobusRegNumber + " " + autobus.AutobusType.TypeName);
            }
        }

    }
}
