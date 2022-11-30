using System.Collections;
using System.ComponentModel;

namespace Ovn5
{
    internal class Handler : IHandler
    {
        private Garage<IVehicle> garage = new Garage<IVehicle>(20);
        private const string messageAddedVehicle = "The following vehicle has just now parked in the garage.";
        private const string messageFindVehicle = "\nWe found the following vehicle parked in our garage:\n";
        private const string messageWelcomeVehicles = "These are the various types of Vehicles that are welcome to park in our Garage\n";
        public Garage<IVehicle> Garage
        {
            get => garage;
            set => garage = value;
        }
        public IEnumerator<IHandler> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Adds a vehicle to the Vehicles array. <br></br>
        /// A Vehicle parks in the Garage.
        /// </summary>
        public void ParkInTheGarageVehicle(Vehicle.Type type, string registrationNumber, ConsoleColor color, int numberOfWheels, int uniqueProperty, string brand = "", Fuel fuel = new Fuel())
        {
            var vehiclesArray = garage.Vehicles.ToList();

            switch (type)
            {
                case Vehicle.Type.Airplane:
                    Airplane airplane = new(Vehicle.Type.Airplane, registrationNumber, color, numberOfWheels, uniqueProperty);
                    vehiclesArray.Add(airplane);
                    break;
                case Vehicle.Type.Boat:
                    Boat boat = new(Vehicle.Type.Boat, registrationNumber, color, Convert.ToInt32(uniqueProperty), numberOfWheels);
                    vehiclesArray.Add(boat);
                    break;
                case Vehicle.Type.Bus:
                    Bus bus = new(Vehicle.Type.Bus, registrationNumber, color, numberOfWheels, Convert.ToInt32(uniqueProperty));
                    vehiclesArray.Add(bus);
                    break;
                case Vehicle.Type.Car:
                    Car car = new(Vehicle.Type.Car, brand, registrationNumber, color, numberOfWheels, fuel);
                    vehiclesArray.Add(car);
                    break;
                case Vehicle.Type.Motorcycle:
                    Motorcycle motorcycle = new Motorcycle(Vehicle.Type.Motorcycle, registrationNumber, color, numberOfWheels, Convert.ToInt32(uniqueProperty));
                    vehiclesArray.Add(motorcycle);
                    break;
                default:
                    break;
            }
            garage.Vehicles = vehiclesArray.ToArray();

            Console.WriteLine($"The following vehicle has now parked: {garage.Vehicles.Last().RegistrationNumber}");
            FindVehicleByRegistration(registrationNumber, false);
            PrintVehiclesParking(false);

        }
        /// <summary>
        /// Using this method instead of the method GetVehiclesByType(object obj)<br></br>
        /// lets one control the content of the property labels<br></br>
        /// that are printed to the Console.
        /// </summary>
        /// <param name="type"></param>
        internal void GetVehicles(Vehicle.Type type, bool seed)
        {
            if (seed)
            {
                garage.SeedWithVehicles();
            }


            switch (type)
            {
                case Vehicle.Type.Airplane:
                    GetAirplanes();
                    break;
                case Vehicle.Type.Boat:
                    GetBoats();
                    break;
                case Vehicle.Type.Bus:
                    GetBuses();
                    break;
                case Vehicle.Type.Car:
                    GetCars();
                    break;
                case Vehicle.Type.Motorcycle:
                    GetMotorcyles();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Creates an empty garage.
        /// </summary>
        /// <param name="capacity"></param>
        public void CreateGarage(int capacity)
        {
            Garage<IVehicle> garageFromUI = new Garage<IVehicle>(capacity);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nA garage with {capacity} parking lots was succesfully created!\n");
        }
        public void GetAirplanes()
        {
            IEnumerable<Airplane> airplaneQuery = garage.Vehicles.OfType<Airplane>();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nA I R P L A N E S");
            Console.WriteLine("...........................\n");
            Console.WriteLine($"Count: {airplaneQuery.Count()}");
            Console.WriteLine("...........................\n");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var vehicle in airplaneQuery)
            {
                Console.WriteLine("Vehicle: " + vehicle.type);
                Console.WriteLine("Registration number: " + vehicle.RegistrationNumber);
                Console.WriteLine("Color: " + vehicle.color);
                Console.WriteLine("Number of wheels: " + vehicle.NumberOfWheels);
                Console.WriteLine("Number of engines: " + vehicle.NumberOfEngines + "\n");
            }
        }
        public void GetBoats()
        {
            IEnumerable<Boat> boatQuery = garage.Vehicles.OfType<Boat>();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nB O A T S");
            Console.WriteLine("...........................\n");
            Console.WriteLine($"Count: {boatQuery.Count()}");
            Console.WriteLine("...........................\n");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var vehicle in boatQuery)
            {
                Console.WriteLine("Vehicle: " + vehicle.type);
                Console.WriteLine("Registration number: " + vehicle.RegistrationNumber);
                Console.WriteLine("Color: " + vehicle.color);
                Console.WriteLine("Number of wheels: " + vehicle.NumberOfWheels);
                Console.WriteLine("Length: " + vehicle.Length + "\n");
            }
        }
        public void GetBuses()
        {
            IEnumerable<Bus> busQuery = garage.Vehicles.OfType<Bus>();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nB U S E S");
            Console.WriteLine("...........................\n");
            Console.WriteLine($"Count: {busQuery.Count()}");
            Console.WriteLine("...........................\n");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var vehicle in busQuery)
            {
                Console.WriteLine("Vehicle: " + vehicle.type);
                Console.WriteLine("Registration number: " + vehicle.RegistrationNumber);
                Console.WriteLine("Color: " + vehicle.color);
                Console.WriteLine("Number of wheels: " + vehicle.NumberOfWheels);
                Console.WriteLine("Number of seats: " + vehicle.Seats + "\n");
            }
        }
        public void GetCars()
        {
            IEnumerable<Car> carQuery = garage.Vehicles.OfType<Car>();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nC A R S");
            Console.WriteLine("...........................\n");
            Console.WriteLine($"Count: {carQuery.Count()}");
            Console.WriteLine("...........................\n");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var vehicle in carQuery)
            {
                Console.WriteLine("Vehicle: " + vehicle.type);
                Console.WriteLine(vehicle.Brand);
                Console.WriteLine("Registration number: " + vehicle.RegistrationNumber);
                Console.WriteLine("Color: " + vehicle.color);
                Console.WriteLine("Number of wheels: " + vehicle.NumberOfWheels);
                Console.WriteLine("Fuel type:" + vehicle.Fuel + "\n");
            }
        }
        public void GetMotorcyles()
        {
            IEnumerable<Motorcycle> motorcycleQuery = garage.Vehicles.OfType<Motorcycle>();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nM O T O R C Y C L E S");
            Console.WriteLine("...........................\n");
            Console.WriteLine($"Count: {motorcycleQuery.Count()}");
            Console.WriteLine("...........................\n");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var vehicle in motorcycleQuery)
            {
                Console.WriteLine("Vehicle: " + vehicle.type);
                Console.WriteLine("Registration number: " + vehicle.RegistrationNumber);
                Console.WriteLine("Color: " + vehicle.color);
                Console.WriteLine("Number of wheels: " + vehicle.NumberOfWheels);
                Console.WriteLine("Cylinder volume:" + vehicle.CylinderVolume + "\n");
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<IHandler> IEnumerable<IHandler>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// The method display each type of Vehicle and its properties.<br></br>
        /// If more controll is wanted, use instead the GetVehicles(Type type) method.
        /// </summary>
        /// <param name="type">Is an enum representing the vehicle sub class.</param>
        public void GetVehiclesByType(Vehicle.Type type) //Creates and displays the vehicles.
        {
            SeedWithVehicles();//Only creates the vehicles. No display.

            IEnumerable<Vehicle> vehicleQuery = null; //Placeholder for an enumerator.

            switch (type) //Gets a Result View of respective Vehicle.
            {
                case Vehicle.Type.Airplane:
                    vehicleQuery = garage.Vehicles.OfType<Airplane>();
                    break;
                case Vehicle.Type.Boat:
                    vehicleQuery = garage.Vehicles.OfType<Boat>();
                    break;
                case Vehicle.Type.Bus:
                    vehicleQuery = garage.Vehicles.OfType<Bus>();
                    break;
                case Vehicle.Type.Car:
                    vehicleQuery = garage.Vehicles.OfType<Car>();
                    break;
                case Vehicle.Type.Motorcycle:
                    vehicleQuery = garage.Vehicles.OfType<Motorcycle>();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid choice!");
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            if (!vehicleQuery!.FirstOrDefault()!.GetType().Name.ToUpper().EndsWith("S"))
            {
                Console.Write(vehicleQuery!.FirstOrDefault()!.GetType().Name.ToUpper() + "S");
            }
            else //Aesthetics for BUS that needs to end with ES in plural.
            {
                Console.Write(vehicleQuery!.FirstOrDefault()!.GetType().Name.ToUpper() + "ES");
            }

            Console.WriteLine($" Count:  {vehicleQuery!.Select(x => x.GetType().Name).Count()}");
            Console.WriteLine("..........................\n");

            foreach (var vehicle in vehicleQuery!)
            {
                PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(vehicle);

                foreach (PropertyDescriptor property in propertyDescriptorCollection)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(property.DisplayName + ": ");
                    //Console.Write(property.Description + " ");
                    Console.WriteLine(property.GetValue(vehicle));
                }
                Console.WriteLine();
            }
        }
        public void SeedWithVehicles()
        {
            garage.SeedWithVehicles();
        }
        public int GetVehiclesParkedInGarage()
        {
            return garage.Vehicles.Count();
        }
        public void SelectExistingVehicleTypes()
        {
            SeedWithVehicles();

            var result = garage.Vehicles.Select(vehicle => vehicle.GetType().Name).Distinct();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{messageWelcomeVehicles}");
            Console.ForegroundColor = ConsoleColor.Cyan;

            foreach (var item in result)
            {
                Console.WriteLine($"{item}\n");
            }
            Console.WriteLine();
        }
        public void FindVehicleByRegistration(string registrationNumber, bool seed)
        {
            if (seed)
            {
                SeedWithVehicles();
            }

            var result = garage.Vehicles.Where(v => v.RegistrationNumber == registrationNumber);

            foreach (var item in result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{messageFindVehicle}\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{item.GetType().Name}\n");
                Console.WriteLine("´´´´´´´´´´´´´´´´´´´´´´´´´´´´");

                foreach (var vehicle in result!)
                {
                    //This is used to be able to get all the properties from all the types of vehicles.
                    //Othewise we only get the three from the base class: Vehicle.
                    PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(vehicle).Sort();

                    foreach (PropertyDescriptor property in propertyDescriptorCollection)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(property.DisplayName + ": ");
                        Console.WriteLine(property.GetValue(vehicle));
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("´´´´´´´´´´´´´´´´´´´´´´´´´´´´\n");
                }
            }
        }
        /// <summary>
        /// Find vehicles by their properties.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="seed"></param>
        public void FindVehicleByProperty(string intType, string attribute, bool seed)
        {// UNDER CONSTRUCTION >>>>>
            Vehicle.Type type = new Vehicle.Type();

            switch (intType)
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
            }

            if (seed)
            {
                SeedWithVehicles();
            }

            var result = garage.Vehicles.Where(v => v.NumberOfWheels == Convert.ToInt32(attribute));

            foreach (var item in result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{messageFindVehicle}\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{item.GetType().Name}\n");
                Console.WriteLine("´´´´´´´´´´´´´´´´´´´´´´´´´´´´");

                foreach (var vehicle in result!)
                {
                    //This is used to be able to get all the properties from all the types of vehicles.
                    //Othewise we only get the three from the base class: Vehicle.
                    PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(vehicle).Sort();

                    foreach (PropertyDescriptor property in propertyDescriptorCollection)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(property.DisplayName + ": ");
                        Console.WriteLine(property.GetValue(vehicle));
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("´´´´´´´´´´´´´´´´´´´´´´´´´´´´\n");
                }
               // PrintVehiclesParking(false);
            }
        }
        /// <summary>
        /// Removes a vehicle from the Vehicles array. <br></br>
        /// A Vehicle leaves the Garage.
        /// </summary>
        public void LeaveTheGarage(string registrationNumber)
        {
            var result = garage.Vehicles.Where(vehicle => vehicle.RegistrationNumber == registrationNumber);
            bool notParked = result.Any(v => v.RegistrationNumber == registrationNumber);

            if (!notParked)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nThere is currently no vehicle parked in the Garage with this number:" +
                    $" {registrationNumber}\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"The vehicle with the following registration number is now leaving: ");
                Console.Write($"{registrationNumber}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n");
                Console.WriteLine("P A R K I N G   updated list\n");

                foreach (var itemRegNoCheck in result!)
                {
                    if (itemRegNoCheck.RegistrationNumber == registrationNumber)
                    {
                        garage.Vehicles = garage.Vehicles.Where(element => element != itemRegNoCheck).ToArray();
                        break; //The Vehicle with the admitted registration number will be excluded from the array.
                    }
                }
                PrintVehiclesParking(false);
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Animate(registrationNumber, 500);
                Console.Write(" has left the garage.\n\n");
            }
        }
        public void PrintVehiclesParking(bool seed)//The boolean seed needs to be set to TRUE if the garage has no vehicles.
        {
            if (seed)
            {
                SeedWithVehicles();
            }

            Console.Write("Reg No      ");
            Console.Write("Vehicle      \n");
            Console.WriteLine("......      ..........");

            var result = garage.Vehicles.Where(vehicle => vehicle != null);

            foreach (var vehicleToPrint in result)//Print the vechicles that are still parking in the Garage.
            {
                Console.WriteLine(vehicleToPrint.RegistrationNumber
                    + "      " + "" + vehicleToPrint.GetType().Name);
            }
        }
        public void Animate(string text, int time)
        {
            int index = 1;
            do
            {
                foreach (char c in text)
                {
                    ++index;
                    Console.Write(c + "");
                    Thread.Sleep(time);
                }
            } while (text.Length > index);
        }
        public void AnimateWord(string text, int time)
        {
            int index = 1;
            do
            {
                ++index;
                Console.Write(text);
                Thread.Sleep(time);

            } while (11 > index); //10 times
        }
        public void SnippetAnyKeyToExit()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
