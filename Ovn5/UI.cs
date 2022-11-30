
using System;
using System.Collections;

namespace Ovn5
{
    internal class UI : IUI

    {
        private const string bananaGarage = "Welcome to \"The Wacky Garage\"\n" +
            "777 Rodeo Drive, Banana Hills, California, USA";
        private string menuMainTitle = "The Main Menu";
        string menuGarageTitle = "The Garage Menu";
        private const string menuOptions = "\nPlease navigate the menu by inputting the number " +
                    "\n[1, 2, 3, 0] of your choice";
        private const string menuOptionsGarage = "\nPlease navigate the menu by inputting the number " +
            "\n(1, 2, 3 , 4, 5, 6, 7, 8, 0) of your choice";
        private const string menuSubPopulate = "2. Populate the Garage with a preset number of Vehicles";
        private const string menuSubListTypesandQuantity = "1. List vehicle types and count for each";
        private readonly Manager<IVehicle> managerUI = new Manager<IVehicle>();
        private char typeVehicle = ' ';
        private const string errorMessageValidNumber = "Please, enter a valid number!";
        private const string menuSubParkedPresetQuantity = "You have now successfully parked vehicles in our beautiful garage!";

        /// <summary>
        /// The UI of the Garage Console application.
        /// </summary>
        public UI()
        {

        }
        /// <summary>
        /// Sets the application title and heading.
        /// </summary>
        public void SetConsoleTitle()
        {
            Console.Title = "C# Övning 5 - Garage 1.0";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{bananaGarage}");
            Console.WriteLine("..............................................................................\n");
        }
        /// <summary>
        /// The Garage Main menu.
        /// </summary>
        public void GetMainMenu()
        {
            while (true)
            {
                Console.Clear();
                SetConsoleTitle();
                Console.Title = $"{bananaGarage}    {menuMainTitle}       {Console.Title}";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine($"{menuMainTitle}");
                Console.WriteLine("\n..............................................................................");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{menuOptions}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                      "\n1. Create a Garage"
                    + "\n2. Go to the Garage Menu"
                    + "\n3. Test"
                    + "\n0. Exit the application");

                char input = ' '; //Creates the character input to be used with the switch-case below.
                string strInput = "";
                int capacity = 0;

                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nInput: ");
                    strInput = Console.ReadLine();
                    input = strInput![0]; //Tries to set input to the first char of the string                                              
                    Console.WriteLine();
                    int option;
                    bool success = Int32.TryParse(strInput, out option); //Check if any letters.

                    if (option != 0 //Validation
                        && option != 1
                        && option != 2
                        && option != 3
                        || option > 3 //Highest valid option is 3.
                        && strInput.Length > 1 //Only 1 char can be entered.
                        || !success) //There was a letter in the input stream.
                    {
                        ErrorMessageMenuOptions();
                    }
                }
                catch (IndexOutOfRangeException) //If the input is faulty an error message is written to the console.
                {
                    ErrorMessageMenuOptions();
                }
                switch (input)
                {
                    case '1':
                        Console.Write("\nNumber of parking lots: ");
                        Int32.TryParse(Console.ReadLine(), out capacity);
                        if (capacity == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nThe entered option is not valid!\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Valid option is a number.");
                            Console.ReadKey();
                            GetMainMenu();
                        }
                        managerUI.CreateGarage(capacity);
                        SnippetAnyKeyToExit();
                        break;
                    case '2':
                        GetSubMenuGarage();//For Garage searches.
                        SnippetAnyKeyToExit();
                        break;
                    case '3':
                        Console.ForegroundColor = ConsoleColor.Red;
                        Animate("Testing in progress ...   ...   ...  N O T :(\n");
                        SnippetAnyKeyToExit();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nPlease enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }
        private void ErrorMessageMenuOptions()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThe entered option is not valid!\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Valid options are: 0, 1, 2, 3");
            Console.ReadKey();
            GetMainMenu();
        }
        /// <summary>
        /// The Garage Submenu.
        /// </summary>
        public void GetSubMenuGarage()
        {
            while (true)
            {
                SubMenuOptions();

                char input = ' '; //Creates the character input to be used with the switch-case below.

                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nInput: ");
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line

                    if (input.ToString().Length == 1)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{errorMessageValidNumber}");
                        SnippetAnyKeyToExit();
                        GetSubMenuGarage();
                    }
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                }
                switch (input)
                {
                    case '1':
                        InstructionsListVehiclesByTypeAndCount();
                        break;
                    case '2':
                        InstructionsSeedVehicles();
                        break;
                    case '3':
                        InstructionsFindRegistrationNumber();
                        break;
                    case '4':
                        InstructionsChooseOneVehicle();
                        break;
                    case '5':
                        managerUI.SelectExistingVehicleTypes();
                        SnippetAnyKeyToExit();
                        break;
                    case '6':
                        InstructionsParkInTheGarage();
                        break;
                    case '7':
                        InstructionsLeavingGarage();
                        break;
                    case '8':// UNDER CONSTRUCTION >>>>> 
                        Console.Title = "Find vehicle by Property";
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Find vehicles by Properties");
                        Console.WriteLine("Choose a vehicle by number: " +
                            "Airplane: 0, " +
                            "Boat: 1, " +
                            "Bus: 2, " +
                            "Car: 3, " +
                            "Motorcycle: 4");
                        Console.WriteLine("Input vehicle type: ");
                        string inputVehicle = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Unique properties for " +
                            "Airplane: Number Of Engines, " +
                            "Boat: Length, " +
                            "Bus: Seats, " +
                            "Car: Brand, " +
                            "Motorcycle: Cylinder Volume");
                        Console.Write("Input any vehicle property: ");
                        string inputProperty = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Vehicle.Type type = new Vehicle.Type();

                        switch (inputVehicle)
                        {
                            case "0":
                                type = Vehicle.Type.Airplane;
                                break;
                            case "1":
                                type = Vehicle.Type.Boat;
                                break;
                            case "2":
                                type = Vehicle.Type.Bus;
                                break;
                            case "3":
                                type = Vehicle.Type.Car;
                                break;
                            case "4":
                                type = Vehicle.Type.Motorcycle;
                                break;
                            default:
                                break;
                        }// UNDER CONSTRUCTION >>>>>
                        managerUI.FindVehicleByProperty(inputVehicle!, inputProperty!, false);
                        SnippetAnyKeyToExit();
                        break;
                    case '0':
                        GetMainMenu();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nPlease enter some valid input (0, 1, 2, 3, 4, 5, 6, 7, 8)");
                        break;
                }
            }
        }
        /// <summary>
        /// Do all of this when a vehicle wants to park.
        /// </summary>
        private void InstructionsParkInTheGarage()
        {
            //Parking form needs all the props! (Preps for the Add method)
            //Base class: Vehicle(Type type, string registrationNumber, ConsoleColor color, int numberOfWheels)
            //Unique props
            //Airplane: numberOfEngines
            //Boat: Length
            //Bus: Seats
            //Car: Brand, Fuel
            //Motorcycle: Cylinder Volume
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Parking";
            Console.WriteLine("In order to park you need to fill out the entire form below.");
            Console.WriteLine("\nChoose a type of vehicle to park\n");
            Console.WriteLine("Airplane 0, Boat 1, Bus 2, Car 3, Motorcycle 4 ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Input Vehicle:");
            string inputVehicle = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Input Registration number:");
            string inputRegistrationNumber = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Color: Black 0, Blue 1, Gray 2, Green 3, Red 4, Yellow 5, White 6");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Input Color:");
            string inputColor = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Input Number Of Wheels: ");
            string inputNumberOfWheels = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Unique properties for Airplane: Number Of Engines, Boat: Length, Bus:  Seats," +
                " Car: Brand , Motorcycle:  Cylinder Volume");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Input for Unique property: ");
            string inputUniqueProperty = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Fuel options:\n" +
                "Biogas 0,\nDiesel 1,\nEthanol 2,\nElectricity 3,\nHVO100 4,\nPetrol 5");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Input Fuel (For Cars Only):");
            string inputCarFuel = Console.ReadLine();
            Console.WriteLine();
            int index = 0;
            Fuel fuel = new Fuel();
            string fuelName = "";
            if (!string.IsNullOrEmpty(inputCarFuel))
            {
                index = Convert.ToInt32(inputCarFuel);

                foreach (int value in Enum.GetValues(typeof(Fuel)))
                {
                    if (value == index)
                    {
                        fuelName = fuel.GetType().GetEnumName(value);
                        break;
                    }
                }
                if (index == 0)
                {
                    fuel = Fuel.Biogas;
                }
                else if (index == 1)
                {
                    fuel = Fuel.Diesel;
                }
                else if (index == 2)
                {
                    fuel = Fuel.Ethanol;
                }
                else if (index == 3)
                {
                    fuel = Fuel.Electricity;
                }
                else if (index == 4)
                {
                    fuel = Fuel.HVO100;
                }
                else if (index == 5)
                {
                    fuel = Fuel.Petrol;
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            ConsoleColor consoleColor = new ConsoleColor();

            if (inputColor![0] == '0')
            {
                consoleColor = ConsoleColor.Black;
            }
            else if (inputColor[0] == '1')
            {
                consoleColor = ConsoleColor.Blue;
            }
            else if (inputColor[0] == '2')
            {
                consoleColor = ConsoleColor.Gray;
            }
            else if (inputColor[0] == '3')
            {
                consoleColor = ConsoleColor.Green;
            }
            else if (inputColor[0] == '4')
            {
                consoleColor = ConsoleColor.Red;
            }
            else if (inputColor[0] == '5')
            {
                consoleColor = ConsoleColor.Yellow;
            }
            else if (inputColor[0] == '6')
            {
                consoleColor = ConsoleColor.White;
            }

            switch (inputVehicle)
            {
                case "0":
                    managerUI.ParkInTheGarageVehicle(Vehicle.Type.Airplane, inputRegistrationNumber!, consoleColor, Convert.ToInt32(inputNumberOfWheels), Convert.ToInt32(inputUniqueProperty));
                    break;
                case "1":
                    managerUI.ParkInTheGarageVehicle(Vehicle.Type.Boat, inputRegistrationNumber!, consoleColor, Convert.ToInt32(inputNumberOfWheels), Convert.ToInt32(inputUniqueProperty));
                    break;
                case "2":
                    managerUI.ParkInTheGarageVehicle(Vehicle.Type.Bus, inputRegistrationNumber!, consoleColor, Convert.ToInt32(inputNumberOfWheels), Convert.ToInt32(inputUniqueProperty));
                    break;
                case "3":
                    managerUI.ParkInTheGarageVehicle(Vehicle.Type.Car, inputRegistrationNumber!, consoleColor, Convert.ToInt32(inputNumberOfWheels), 0, inputUniqueProperty!, fuel);
                    break;
                case "4":
                    managerUI.ParkInTheGarageVehicle(Vehicle.Type.Motorcycle, inputRegistrationNumber!, consoleColor, Convert.ToInt32(inputNumberOfWheels), Convert.ToInt32(inputUniqueProperty));
                    break;
                default:
                    break;
            }
            SnippetAnyKeyToExit();
        }

        public void InstructionsLeavingGarage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThis is the inventory of the vehicles parking in \"The Wacky Garage\"");
            Console.WriteLine("Banana Hills, California, USA\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            managerUI.PrintVehiclesParking(false);//Get the current parking list.
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Which vehicle is going to leave the garage?";
            Console.WriteLine("\nWhich vehicle is going to leave the garage?");

            Console.Write("Enter the Registration number as letters/numbers, ex. ABC123:  ");
            string registrationNumber = Console.ReadLine()!.ToUpper();

            managerUI.FindVehicleByRegistration(registrationNumber, false);
            managerUI.LeaveTheGarage(registrationNumber);
            SnippetAnyKeyToExit();
        }

        /// <summary>
        /// Listing of the Garage Submenu options.
        /// </summary>
        private void SubMenuOptions()
        {
            Console.Clear();
            SetConsoleTitle();
            Console.Title = $"  ¨¨¨¨  {menuGarageTitle}  ¨¨¨¨     {Console.Title}";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            //Animate(menuGarageTitle);
            Console.WriteLine($"{menuGarageTitle}");
            Console.WriteLine("\n..............................................................................");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{menuOptionsGarage}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n1. List vehicles by");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Type");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" and");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Count");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n2. ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Populate");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" the Garage with all types of Vehicles"
            + "\n3. Find a Vehicle by the ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Registration number");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n4. List all vehichles of ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("ONE type");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" now parking");
            Console.Write("\n5. View the types of vehicles that are");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" ALLOWED ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("to park in the Garage");
            Console.Write("\n6. ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Park");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" in the garage");
            Console.Write("\n7. ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Leave ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("the garage");
            Console.Write("\n8. Find vehicles by ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Property");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n0. Go to the Main Menu\n");
        }
        /// <summary>
        /// Submenu option.Choose All types of vehicles and list the vehicles.
        /// </summary>
        private void InstructionsListVehiclesByTypeAndCount()
        {
            Console.ForegroundColor = ConsoleColor.White;
            managerUI.PopulateGarage();
            Console.Title = $"  ¨¨¨¨  {menuSubListTypesandQuantity}  ¨¨¨¨     {Console.Title}";
            SnippetAnyKeyToExit();
        }
        /// <summary>
        /// Seed a number of different types of vehicles and show them.
        /// </summary>
        private void InstructionsSeedVehicles()
        {
            managerUI.SeedWithVehicles();
            Console.Title = $"  ¨¨¨¨  {menuSubParkedPresetQuantity}  ¨¨¨¨     {Console.Title}";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("You have now successfully parked: ");
            Console.WriteLine($"{managerUI.GetVehiclesParkedInGarage()} " +
                $"vehicles in our beautiful garage!\n");
            SnippetAnyKeyToExit();
        }
        /// <summary>
        /// Submenu option.Choose One vehicle type and list the vehicles.
        /// </summary>
        private void InstructionsChooseOneVehicle()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose a type of vehicle from the Garage");
            Console.WriteLine("Airplane: 0, Boat: 1, Bus: 2, Car: 3, Motorcycle: 4 ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Input: ");

            object? vehicle = Vehicle.Type.Airplane;//Default value

            try
            {
                typeVehicle = Console.ReadLine()![0]; //Tries to set input to the first char
                Console.WriteLine("\n");

                if (typeVehicle == '0') //Select type of Vehicle.
                {
                    vehicle = Vehicle.Type.Airplane;
                }
                else if (typeVehicle == '1')
                {

                    vehicle = Vehicle.Type.Boat;
                }
                else if (typeVehicle == '2')
                {

                    vehicle = Vehicle.Type.Bus;
                }
                else if (typeVehicle == '3')
                {
                    vehicle = Vehicle.Type.Car;
                }
                else if (typeVehicle == '4')
                {
                    vehicle = Vehicle.Type.Motorcycle;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{errorMessageValidNumber}");
                    SnippetAnyKeyToExit();
                    GetSubMenuGarage();
                }
                Console.ForegroundColor = ConsoleColor.White;
                managerUI.GetVehicles(vehicle, false);
                SnippetAnyKeyToExit();
            }
            catch (IndexOutOfRangeException)
            {
                Console.Clear();
            }
        }
        /// <summary>
        /// Submenu option. Find a vehichle by its registration number. 
        /// </summary>
        private void InstructionsFindRegistrationNumber()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the Registration number as letters/numbers, ex. ABC123:  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string registrationNumber = Console.ReadLine()!.ToUpper();
            managerUI.FindVehicleByRegistration(registrationNumber!, false);
            SnippetAnyKeyToExit();
        }
        /// <summary>
        /// Animate any text.
        /// </summary>
        public void Animate(string text)
        {
            int index = 1;
            do
            {
                foreach (char c in text)
                {
                    ++index;
                    Console.Write(c);
                    Thread.Sleep(100);
                }
            } while (text.Length > index);
        }
        IEnumerator<IUI> IEnumerable<IUI>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Submenu snippet. Exit.
        /// </summary>
        public void SnippetAnyKeyToExit()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
