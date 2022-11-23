using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ovn5
{
    /// <summary>
    /// The abstract class Vehicle to be used as a base class for any type of vehicle.<br></br>
    /// It cannot be instantiated since it is abstract
    /// </summary>
    internal abstract class Vehicle : IVehicle
    {
        protected string registrationNumber = string.Empty;//Get by ID
        protected ConsoleColor ConsoleColor;
        protected int numberOfWheels;

        public Vehicle(string registrationNumber, ConsoleColor color, int numberOfWheels)
        {
            this.registrationNumber = registrationNumber;
            ConsoleColor = color;
            this.numberOfWheels = numberOfWheels;
        }
        public string RegistrationNumber
        {
            get => registrationNumber;
            set => registrationNumber = value;
        }
        public ConsoleColor color
        {
            get => ConsoleColor;
            set => ConsoleColor = value;
        }
        public int NumberOfWheels
        {
            get => numberOfWheels;
            set => numberOfWheels = value;
        }

        public enum Type
        {
            Airplane,
            Boat,
            Bus,
            Car,
            Motorcycle
        }

    }
}
