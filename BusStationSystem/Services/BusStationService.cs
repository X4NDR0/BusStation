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
        private static List<Ticket> ticketList = new List<Ticket>();
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

                    case Menu.BusStationMenu:
                        Console.Clear();
                        BusStationMenu();
                        break;

                    case Menu.TicketMenu:
                        Console.Clear();
                        TicketMenu();
                        break;

                    case Menu.exit:
                        Environment.Exit(0);
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
            Console.WriteLine("4.Bus Station menu");
            Console.WriteLine("5.Ticket menu");
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

                Console.Write("Enter new name and lastname of the transportaion company:");
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

                Enum.TryParse(Console.ReadLine(), out AutobusType);

                Autobus editAutobus = new Autobus { AutobusRegNumber = newRegNum, AutobusType = AutobusType };

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
            Int32.TryParse(Console.ReadLine(), out int newRegNum);

            Autobus CheckID = autobusList.Where(x => x.AutobusRegNumber == newRegNum).FirstOrDefault();

            if (CheckID != null)
            {
                Console.WriteLine("Autobus with that registration number already exits!");
            }
            else
            {
                TipAutobusa AutobusType;
                do
                {
                    Console.Write("Select autobus type:\n");
                    Console.WriteLine("1.Jednospratni");
                    Console.WriteLine("2.Dvospratni");
                    Console.WriteLine("3.Mini Bus");
                    Console.Write("Select:");
                    Enum.TryParse(Console.ReadLine(), out AutobusType);
                } while (Enum.IsDefined(typeof(TipAutobusa), AutobusType) == false);

                Autobus addAutobus = new Autobus { AutobusRegNumber = newRegNum, AutobusType = AutobusType };

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
            Int32.TryParse(Console.ReadLine(), out int select);

            switch (select)
            {
                case 1:
                    Console.Clear();
                    WriteAllBusStation();
                    break;

                case 2:
                    Console.Clear();
                    EditBusStation();
                    break;

                case 3:
                    Console.Clear();
                    RemoveBusStation();
                    break;

                case 4:
                    Console.Clear();
                    AddBusStation();
                    break;

                default:
                    Console.WriteLine("That option does not exits!");
                    break;
            }
        }

        private void WriteAllBusStation()
        {
            foreach (BusStation busStation in busStationList)
            {
                Console.WriteLine(busStation.BusStationID + " " + busStation.Location + " Peron ID:" + busStation.Peron.PeronID + " Peron Arrival And Deperture:" + busStation.Peron.ArrivalDeparture);
            }
        }

        private void EditBusStation()
        {
            Console.WriteLine("Enter ID of the bus station:");
            Int32.TryParse(Console.ReadLine(), out int select);

            BusStation CheckID = busStationList.Where(x => x.BusStationID == select).FirstOrDefault();

            Peron peronEdit = new Peron();

            if (CheckID != null)
            {
                Console.Write("Enter a new ID of the bus station:");
                Int32.TryParse(Console.ReadLine(), out int newID);

                Console.Write("Enter a new location of the bus station:");
                string newLocation = Console.ReadLine();

                WriteAllPerons();
                Console.Write("Enter a new peron across ID:");
                Int32.TryParse(Console.ReadLine(), out int newPeron);

                Peron FindPeronID = peronList.Where(x => x.PeronID == newPeron).FirstOrDefault();

                if (FindPeronID != null)
                {
                    peronEdit = FindPeronID;
                }
                else
                {
                    Console.WriteLine("Sorry,but that peron does not exits!");
                }

                BusStation editBusStation = new BusStation { BusStationID = newID, Location = newLocation, Peron = peronEdit };

                int indexObject = busStationList.IndexOf(CheckID);
                busStationList[indexObject] = editBusStation;

            }
            else
            {
                Console.WriteLine("Sorry,but that id does not exits!");
            }
        }

        private void RemoveBusStation()
        {
            Console.Write("Enter bus station ID:");
            Int32.TryParse(Console.ReadLine(), out int removeID);

            BusStation CheckID = busStationList.Where(x => x.BusStationID == removeID).FirstOrDefault();

            if (CheckID != null)
            {
                busStationList.Remove(CheckID);
                Console.WriteLine("Bus Station is successfully removed!");
            }
            else
            {
                Console.WriteLine("That ID does not exits!");
            }
        }

        private void AddBusStation()
        {
            Console.Write("Enter a new ID:");
            Int32.TryParse(Console.ReadLine(), out int newID);

            BusStation CheckID = busStationList.Where(x => x.BusStationID == newID).FirstOrDefault();

            if (CheckID != null)
            {
                Console.WriteLine("That ID is aleardy exits!");
            }
            else
            {
                Console.Write("Enter a new location:");
                string newLocation = Console.ReadLine();

                WriteAllPerons();
                Console.Write("Enter peron ID:");
                Int32.TryParse(Console.ReadLine(), out int peronID);

                Peron FindPeron = peronList.Where(x => x.PeronID == peronID).FirstOrDefault();

                if (FindPeron != null)
                {
                    Peron newPeron;
                    newPeron = FindPeron;

                    BusStation newBusStation = new BusStation { BusStationID = newID, Location = newLocation, Peron = FindPeron };

                    busStationList.Add(newBusStation);
                }
                else
                {
                    Console.WriteLine("That ID does not exits!");
                }
            }
        }

        //Ticket

        private void TicketMenu()
        {
            Console.WriteLine("1.Write all tickets");
            Console.WriteLine("2.Edit ticket");
            Console.WriteLine("3.Remove ticket");
            Console.WriteLine("4.Add ticket");
            Console.Write("Option:");
            Int32.TryParse(Console.ReadLine(), out int option);

            switch (option)
            {
                case 1:
                    Console.Clear();
                    WriteAllTickets();
                    break;

                case 2:
                    Console.Clear();
                    EditTicket();
                    break;

                default:
                    Console.WriteLine("That option does not exits!");
                    break;
            }
        }

        private void WriteAllTickets()
        {
            foreach (Ticket ticket in ticketList)
            {
                Console.WriteLine(ticket.TicketId + " " + ticket.Autobus.AutobusType + " " + ticket.TransportationCompany.TransportationCompanyName + " Starting:" + ticket.BusStationStarting.Location + " Arrival:" + ticket.BusStationArrival.Location);
            }
        }

        //private void EditTicket()
        //{
        //    //Objects for edit
        //    TransportationCompany tcEdit;
        //    Autobus abEdit;
        //    BusStation bsStart;
        //    BusStation bsArrival;

        //    Console.Write("Enter ticket ID:");
        //    Int32.TryParse(Console.ReadLine(),out int editID);

        //    Ticket CheckID = ticketList.Where(x => x.TicketId == editID).FirstOrDefault();

        //    if (CheckID != null)
        //    {
        //        Console.Write("Enter a new ticket ID:");
        //        Int32.TryParse(Console.ReadLine(),out int newID);

        //        WriteAllTransportaionCompany();
        //        Console.Write("Enter TC id:");
        //        Int32.TryParse(Console.ReadLine(),out int newTcID);

        //        TransportationCompany tcCheck = transportationCompanyList.Where(x => x.TransportationCompanyID == newTcID).FirstOrDefault();

        //        if (tcCheck != null)
        //        {
        //            tcEdit = tcCheck;

        //            WriteAllAutobuses();
        //            Console.Write("Enter autobus reg number:");
        //            Int32.TryParse(Console.ReadLine(),out int regNumEdit);

        //            Autobus abCheck = autobusList.Where(x => x.AutobusRegNumber == regNumEdit).FirstOrDefault();

        //            if (abCheck != null)
        //            {
        //                abEdit = abCheck;

        //                WriteAllBusStation();
        //                Console.Write("Enter id of starting station:");
        //                Int32.TryParse(Console.ReadLine(),out int startStation);

        //                BusStation startBS = busStationList.Where(c => c.BusStationID == startStation).FirstOrDefault();

        //                if (startBS != null)
        //                {
        //                    bsStart = startBS;

        //                    Console.Write("Enter id of arrival station:");
        //                    Int32.TryParse(Console.ReadLine(),out int arrivalStation);

        //                    BusStation arrivalBS = busStationList.Where(b => b.BusStationID == arrivalStation).FirstOrDefault();

        //                    if (arrivalBS != null)
        //                    {
        //                        bsArrival = arrivalBS;

        //                        Ticket editTicket = new Ticket {TicketId = newID,TransportationCompany = tcEdit,Autobus = abEdit,BusStationStarting = bsStart,BusStationArrival = bsArrival};
        //                        int objectIndex = ticketList.IndexOf(CheckID);
        //                        ticketList[objectIndex] = editTicket;
        //                    }else
        //                    {
        //                        Console.WriteLine("That ID does not exits!");
        //                    }

        //                }else
        //                {
        //                    Console.WriteLine("That ID does not exits!");
        //                }

        //            }
        //            else
        //            {
        //                Console.WriteLine("That ID does not exits!");
        //            }
        //        }else
        //        {
        //            Console.WriteLine("That ID does not exits!");
        //        }

        //    }else
        //    {
        //        Console.WriteLine("That ID does not exits!");
        //    }

        //}

        private void EditTicket()
        {
            //Objects for edit
            TransportationCompany tcEdit;
            Autobus abEdit;
            BusStation bsStart;
            BusStation bsArrival;

            Console.Write("Enter ticket ID:");
            Int32.TryParse(Console.ReadLine(), out int editID);

            Ticket CheckID = ticketList.Where(x => x.TicketId == editID).FirstOrDefault();

            if (CheckID == null)
            {
                Console.WriteLine("That ID does not exits!");
                return;
            }

            Console.Write("Enter a new ticket ID:");
            Int32.TryParse(Console.ReadLine(), out int newID);

            WriteAllTransportaionCompany();
            Console.Write("Enter TC id:");
            Int32.TryParse(Console.ReadLine(), out int newTcID);

            TransportationCompany tcCheck = transportationCompanyList.Where(x => x.TransportationCompanyID == newTcID).FirstOrDefault();

            if (tcCheck == null)
            {
                Console.WriteLine("That ID does not exits!");
                return;
            }

            tcEdit = tcCheck;

            WriteAllAutobuses();
            Console.Write("Enter autobus reg number:");
            Int32.TryParse(Console.ReadLine(), out int regNumEdit);

            Autobus abCheck = autobusList.Where(x => x.AutobusRegNumber == regNumEdit).FirstOrDefault();

            if (abCheck == null)
            {
                Console.WriteLine("That ID does not exits!");
                return;
            }

            abEdit = abCheck;

            WriteAllBusStation();
            Console.Write("Enter id of starting station:");
            Int32.TryParse(Console.ReadLine(), out int startStation);

            BusStation startBS = busStationList.Where(c => c.BusStationID == startStation).FirstOrDefault();

            if (startBS == null)
            {
                Console.WriteLine("That ID does not exits!");
                return;
            }

            bsStart = startBS;

            Console.Write("Enter id of arrival station:");
            Int32.TryParse(Console.ReadLine(), out int arrivalStation);

            BusStation arrivalBS = busStationList.Where(b => b.BusStationID == arrivalStation).FirstOrDefault();

            if (arrivalBS == null)
            {
                Console.WriteLine("That ID does not exits!");
                return;
            }

            bsArrival = arrivalBS;

            Ticket editTicket = new Ticket { TicketId = newID, TransportationCompany = tcEdit, Autobus = abEdit, BusStationStarting = bsStart, BusStationArrival = bsArrival };
            int objectIndex = ticketList.IndexOf(CheckID);
            ticketList[objectIndex] = editTicket;
        }

        private void LoadData()
        {

            Autobus autobus1 = new Autobus { AutobusType = TipAutobusa.MiniBus, AutobusRegNumber = 382729172 };
            Autobus autobus2 = new Autobus { AutobusType = TipAutobusa.Jednospratni, AutobusRegNumber = 55667788 };

            TransportationCompany tc1 = new TransportationCompany { TransportationCompanyID = 2727, TransportationCompanyName = "Nikola Petrovic", TransportationCompanyLocation = "Kragujevac" };
            TransportationCompany tc2 = new TransportationCompany { TransportationCompanyID = 2638, TransportationCompanyName = "Petar Mitrovic", TransportationCompanyLocation = "Subotica" };

            Peron peron1 = new Peron { PeronID = 242, ArrivalDeparture = new DateTime(2019, 4, 4, 6, 30, 00) };
            Peron peron2 = new Peron { PeronID = 532, ArrivalDeparture = new DateTime(2019, 3, 3, 9, 30, 00) };

            BusStation busStation1 = new BusStation { BusStationID = 5832, Location = "Beograd", Peron = peron1 };
            BusStation busStation2 = new BusStation { BusStationID = 9281, Location = "Smederevo", Peron = peron2 };

            Ticket ticket1 = new Ticket { TicketId = 4334, TransportationCompany = tc1, Autobus = autobus1, BusStationArrival = busStation1, BusStationStarting = busStation2 };
            Ticket ticket2 = new Ticket { TicketId = 5555, TransportationCompany = tc2, Autobus = autobus2, BusStationArrival = busStation2, BusStationStarting = busStation1 };

            autobusList.Add(autobus1);
            autobusList.Add(autobus2);

            transportationCompanyList.Add(tc1);
            transportationCompanyList.Add(tc2);

            peronList.Add(peron1);
            peronList.Add(peron2);

            busStationList.Add(busStation1);
            busStationList.Add(busStation2);

            ticketList.Add(ticket1);
            ticketList.Add(ticket2);
        }
    }
}