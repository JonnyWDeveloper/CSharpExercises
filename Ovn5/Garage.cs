using System.Collections;

namespace Ovn5
{
    /// <summary>
    /// A Garage is a represented by a collection of vehicles.<br></br>
    /// It only is responsible for keeping track of the number of cars and parking paces.
    /// </summary>
    /// <typeparam name="T">T is IVehicle. All vehicles are IVehicles.</typeparam>
    public class Garage<T> : IEnumerable<IVehicle> where T : IVehicle
    {
        private Vehicle[] vehicles;
        private int parkingSpaces;
        public Garage(int parkingSpaces, int vehicleCount = 0)
        {
            vehicles = new Vehicle[vehicleCount];
            this.parkingSpaces = parkingSpaces;
        }
        public Vehicle[] Vehicles
        {
            get => vehicles;
            set => vehicles = value;
        }
        /// <summary>
        /// Very good for large sets of data (say: <b>10 000 000</b>.)
        /// <br></br> There is a massive performance booster to use this method.<br></br>                             
        ///However with fewer, say: a <b>1000</b> items, the difference is negligible.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IVehicle> GetEnumerator()
        {
            foreach (var vehicle in vehicles)
            {
                //....... 

                yield return vehicle;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Seeds the Garage with a number of different vehicles.
        /// </summary>
        public void SeedWithVehicles()
        {
            Airplane airplane = new Airplane(Vehicle.Type.Airplane, "ABC123", ConsoleColor.DarkBlue, 6, 4);
            Airplane airplane1 = new Airplane(Vehicle.Type.Airplane, "DEF123", ConsoleColor.Red, 4, 8);
            Airplane airplane2 = new Airplane(Vehicle.Type.Airplane, "GHI123", ConsoleColor.Black, 4, 8);

            Boat boat = new Boat(Vehicle.Type.Boat, "KLM123", ConsoleColor.DarkBlue, 80, 0);
            Boat boat1 = new Boat(Vehicle.Type.Boat, "NOP123", ConsoleColor.DarkBlue, 55, 0);
            Boat boat2 = new Boat(Vehicle.Type.Boat, "QRS123", ConsoleColor.Blue, 100, 0);

            Bus bus = new Bus(Vehicle.Type.Bus, "TUV123", ConsoleColor.Green, 12, 50);
            Bus bus1 = new Bus(Vehicle.Type.Bus, "WXY123", ConsoleColor.Green, 8, 100);
            Bus bus2 = new Bus(Vehicle.Type.Bus, "JKL123", ConsoleColor.Blue, 4, 10);

            Car car = new Car(Vehicle.Type.Car, "Tesla", "MNO123", ConsoleColor.DarkBlue, 4, Fuel.Electricity);
            Car car1 = new Car(Vehicle.Type.Car, "Volvo", "PQR123", ConsoleColor.Red, 8, Fuel.Electricity);
            Car car2 = new Car(Vehicle.Type.Car, "Subaru", "STU123", ConsoleColor.Black, 4, Fuel.Electricity);

            Motorcycle motorcyle = new Motorcycle(Vehicle.Type.Motorcycle, "VWX123", ConsoleColor.Black, 4, 900);
            Motorcycle motorcyle1 = new Motorcycle(Vehicle.Type.Motorcycle, "YZÅ123", ConsoleColor.Black, 4, 900);
            Motorcycle motorcyle2 = new Motorcycle(Vehicle.Type.Motorcycle, "ÅÄÖ123", ConsoleColor.Black, 6, 900);

            vehicles = new Vehicle[15] //5 Types of vehicles
            {
                airplane,airplane1,airplane2,
                boat, boat1,boat2,
                bus, bus1,bus2,
                car, car1, car2,
                motorcyle, motorcyle1, motorcyle2
            };
        }
    }
}
