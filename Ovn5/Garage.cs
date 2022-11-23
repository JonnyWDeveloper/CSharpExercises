using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn5
{
    //Representeras som en samling av fordon.
    //Håller endast reda på antal bilar och antal p-platser
    //Här behöver vi seeda ett antal fordon för att spara tid...
    //Use where...  --> Constraint behövs!
    internal class Garage <T> where T : IEnumerable<T>
    {
        private Vehicle[] vehicles;
        private int parkingSpaces;

        public Garage(int vehicleCount, int parkingSpaces)
        {
            vehicles = new Vehicle[vehicleCount];
            this.parkingSpaces = parkingSpaces;
        }
        internal Vehicle[] Vehicles
        {
            get => vehicles;
            set => vehicles = value;
        }           
    }
}
