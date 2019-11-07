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
        private static List<Peron> peronList = new List<Peron>();
        private static List<BusStation> busStationList = new List<BusStation>();
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
                    case Menu.TCMenu:
                        Console.Clear();
                        MenuCarrier();
                        break;

                    case Menu.PeronMenu:
                        Console.Clear();
                        PeronMenu();
                        break;

                    case Menu.AutobusMenu:
                        Console.Clear();
                        AutobusMenu();
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
            Console.WriteLine("1.Transportation company menu");
            Console.WriteLine("2.Peron menu");
            Console.WriteLine("3.Autobus menu");
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
                    Console.WriteLine("Wrong input!");
                    break;
            }
        }

        private void WriteAllTransportaionCompany()
        {
            foreach (TransportationCompany transportationCompany in transportationCompanyList)
            {
                Console.WriteLine(transportationCompany.TransportationCompanyID + " " + transportationCompany.TransportationCompanyName + " " + transportationCompany.TransportationCompanyLocation);
            }
        }

        private void EditTransportaionCompany()
        {
            Console.Write("Please enter carrier ID:");
            Int32.TryParse(Console.ReadLine(), out int selectID);

            TransportationCompany CheckID = transportationCompanyList.Where(x => x.TransportationCompanyID == selectID).FirstOrDefault();

            if (CheckID != null)
            {
                Console.Write("Enter new ID of the transportaion company:");
                Int32.TryParse(Console.ReadLine(), out int newID);

                Console.Write("Enter new name and lastname of the transportaion company: :");
                string newName = Console.ReadLine();

                Console.Write("Enter new place:");
                string newPlace = Console.ReadLine();

                WriteAllAutobuses();

                Console.Write("Enter ID of the autobus:");
                Int32.TryParse(Console.ReadLine(), out int autobusID);

                Autobus FindAutobus = autobusList.Where(x => x.AutobusRegNumber == autobusID).First();

                List<Autobus> autobusListEdit = new List<Autobus>();
                autobusListEdit.Add(FindAutobus);

                TransportationCompany transportationCompanyEdit = new TransportationCompany { TransportationCompanyID = newID, TransportationCompanyName = newName, TransportationCompanyLocation = newPlace, ListOfBuses = autobusListEdit };

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
            Int32.TryParse(Console.ReadLine(), out int deleteID);

            TransportationCompany DeleteID = transportationCompanyList.Where(x => x.TransportationCompanyID == deleteID).FirstOrDefault();

            if (DeleteID != null)
            {
                transportationCompanyList.Remove(DeleteID);
            }
            else
            {
                Console.WriteLine("Error with ");
            }
        }

        private void AddTransportaionCompany()
        {
            Console.Write("Enter a new ID:");
            Int32.TryParse(Console.ReadLine(), out int newID);

            TransportationCompany addTransportationCompany = transportationCompanyList.Where(x => x.TransportationCompanyID == newID).FirstOrDefault();

            if (addTransportationCompany != null)
            {
                Console.WriteLine("Sorry,but that ID alredy used!");
            }
            else
            {
                Console.Write("Enter a new name:");
                string newName = Console.ReadLine();

                Console.Write("Enter a new place:");
                string newPlace = Console.ReadLine();

                TransportationCompany addTC = new TransportationCompany { TransportationCompanyID = newID, TransportationCompanyName = newName, TransportationCompanyLocation = newPlace };

                transportationCompanyList.Add(addTC);
            }

        }

        //Peron

        private void PeronMenu()
        {
            Console.WriteLine("1.Write all perons");
            Console.WriteLine("2.Edit peron");
            Console.WriteLine("3.Remove peron");
            Console.WriteLine("4.Add peron");
            Console.Write("Unos:");

            Int32.TryParse(Console.ReadLine(), out int menuSelect);

            switch (menuSelect)
            {
                case 1:
                    Console.Clear();
                    WriteAllPerons();
                    break;

                case 2:
                    Console.Clear();
                    EditPeron();
                    break;

                case 3:
                    Console.Clear();
                    RemovePeron();
                    break;

                case 4:
                    Console.Clear();
                    AddPeron();
                    break;

                default:
                    Console.WriteLine("Option does not exits!");
                    break;
            }
        }

        private void WriteAllPerons()
        {
            foreach (Peron peron in peronList)
            {
                Console.WriteLine(peron.PeronID + " " + peron.ArrivalDeparture);
            }
        }

        private void EditPeron()
        {
            Console.Write("Enter ID of the peron:");
            Int32.TryParse(Console.ReadLine(), out int editID);

            Peron CheckID = peronList.Where(x => x.PeronID == editID).FirstOrDefault();

            if (CheckID != null)
            {
                Console.Write("Enter new ID:");
                Int32.TryParse(Console.ReadLine(), out int newID);

                Console.Write("Enter date and time(2019/5/20 5:30:00):");
                DateTime newTime = DateTime.Parse(Console.ReadLine());

                Peron editPeron = new Peron { PeronID = newID, ArrivalDeparture = newTime };

                int findIndex = peronList.IndexOf(CheckID);
                peronList[findIndex] = editPeron;
            }
            else
            {
                Console.WriteLine("That ID does not exits!");
            }
        }

        private void RemovePeron()
        {
            Console.Write("Enter peron ID:");
            Int32.TryParse(Console.ReadLine(), out int removeID);

            Peron CheckID = peronList.Where(x => x.PeronID == removeID).FirstOrDefault();

            if (CheckID != null)
            {
                peronList.Remove(CheckID);
                Console.WriteLine("Peron has deleted!");
            }
            else
            {
                Console.WriteLine("That ID does not exits!");
            }
        }

        private void AddPeron()
        {
            Console.Write("Enter new peron ID:");
            Int32.TryParse(Console.ReadLine(), out int newID);

            Console.Write("Enter date and time(2019/5/20 5:30:00):");
            DateTime newTime = DateTime.Parse(Console.ReadLine());

            Peron addPeron = new Peron { PeronID = newID, ArrivalDeparture = newTime };
            peronList.Add(addPeron);

        }

        //Autobus

        private void AutobusMenu()
        {
            Console.WriteLine("1.Write all autobuses");
            Console.WriteLine("2.Edit autobus");
            Console.WriteLine("3.Remove autobus");
            Console.WriteLine("4.Add autobus");
            Console.Write("Unos:");
            Int32.TryParse(Console.ReadLine(), out int meniSelect);

            switch (meniSelect)
            {
                case 1:
                    Console.Clear();
                    WriteAllAutobuses();
                    break;

                case 2:
                    Console.Clear();
                    EditAutobus();
                    break;

                case 3:
                    Console.Clear();
                    RemoveAutobus();
                    break;

                case 4:
                    Console.Clear();
                    AddAutobus();
                    break;

                default:
                    Console.WriteLine("That option does not exits!");
                    break;
            }
        }

        private void WriteAllAutobuses()
        {
            foreach (Autobus autobus in autobusList)
            {
                Console.WriteLine(autobus.AutobusRegNumber + " " + autobus.AutobusType.ToString());
            }
        }

        private void EditAutobus()
        {
            Console.Write("Enter registration number of the autobus:");
            Int32.TryParse(Console.ReadLine(), out int editID);

            Autobus CheckID = autobusList.Where(x => x.AutobusRegNumber == editID).FirstOrDefault();

            if (CheckID != null)
            {
                Console.Write("Enter new registration number:");
                Int32.TryParse(Console.ReadLine(), out int newRegNum);

                Console.Write("Select autobus type:\n");
                Console.WriteLine("1.Jednospratni");
                Console.WriteLine("2.Dvospratni");
                Console.WriteLine("3.Mini Bus");
                Console.Write("Select:");
                TipAutobusa AutobusType;

                Enum.TryParse(Console.ReadLine(),out AutobusType);

                Autobus editAutobus = new Autobus { AutobusRegNumber = newRegNum, AutobusType = AutobusType};

                int indexAutobus = autobusList.IndexOf(CheckID);
                autobusList[indexAutobus] = editAutobus;
            }
            else
            {
                Console.WriteLine("That registration number does not exits!");
            }
        }

        private void RemoveAutobus()
        {
            Console.Write("Enter autobus registration number to delete:");
            Int32.TryParse(Console.ReadLine(), out int regNumDel);

            Autobus CheckID = autobusList.Where(x => x.AutobusRegNumber == regNumDel).FirstOrDefault();

            if (CheckID != null)
            {
                autobusList.Remove(CheckID);
                Console.WriteLine("Autobus has successfully deleted!");
            }
            else
            {
                Console.WriteLine("That registration number does not exits!");
            }
        }

        private void AddAutobus()
        {
            Console.Write("Enter registration number:");
            Int32.TryParse(Console.ReadLine(),out int newRegNum);

            Autobus CheckID = autobusList.Where(x => x.AutobusRegNumber == newRegNum).FirstOrDefault();

            if (CheckID != null)
            {
                Console.WriteLine("Autobus with that registration number does not exits!");
            }
            else
            {
                TipAutobusa AutobusType;
                Console.Write("Select autobus type:");
                Console.WriteLine("1.Jednospratni");
                Console.WriteLine("2.Dvospratni");
                Console.WriteLine("3.Mini Bus");
                Console.Write("Select:");
                Enum.TryParse(Console.ReadLine(), out AutobusType);

                Autobus addAutobus = new Autobus { AutobusRegNumber = newRegNum,AutobusType = AutobusType};

                autobusList.Add(addAutobus);
            }
        }

        //Bus Station
        private void BusStationMenu()
        {
            Console.WriteLine("1.Write all bus stations");
            Console.WriteLine("2.Edit bus station");
            Console.WriteLine("3.Remove bus station");
            Console.WriteLine("4.Add bus station");
            Console.Write("Unos:");
            Int32.TryParse(Console.ReadLine(),out int select);

            switch (select)
            {
                default:
                    Console.WriteLine("That option does not exits!");
                    break;
            }
        }

        private void WriteAllBusStation()
        {
          
        }

        private void LoadData()
        {

            Autobus autobus1 = new Autobus { AutobusType = TipAutobusa.MiniBus, AutobusRegNumber = 382729172 };
            Autobus autobus2 = new Autobus { AutobusType = TipAutobusa.Jednospratni, AutobusRegNumber = 55667788 };

            TransportationCompany tc1 = new TransportationCompany { TransportationCompanyID = 2727, TransportationCompanyName = "Nikola Petrovic", TransportationCompanyLocation = "Kragujevac" };
            TransportationCompany tc2 = new TransportationCompany { TransportationCompanyID = 2638, TransportationCompanyName = "Petar Mitrovic", TransportationCompanyLocation = "Subotica" };

            Peron peron1 = new Peron { PeronID = 242, ArrivalDeparture = new DateTime(2019, 4, 4, 6, 30, 00) };
            Peron peron2 = new Peron { PeronID = 532, ArrivalDeparture = new DateTime(2019, 3, 3, 9, 30, 00) };

            autobusList.Add(autobus1);
            autobusList.Add(autobus2);

            transportationCompanyList.Add(tc1);
            transportationCompanyList.Add(tc2);

            peronList.Add(peron1);
            peronList.Add(peron2);
        }
    }
}