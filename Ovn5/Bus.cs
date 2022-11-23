using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn5
{
    /// <summary>
    /// The Bus class inheriting from its abstract base class Vehicle
    /// </summary>
    internal class Bus : Vehicle
    {
        private int seats;
        public Bus(string registrationNumber, ConsoleColor color, int numberOfWheels, int seats) : base(registrationNumber, color, numberOfWheels)
        {
            this.seats = seats;
        }
        public int Seats
        {
            get => seats;
            set => seats = value;
        }
    }
}
