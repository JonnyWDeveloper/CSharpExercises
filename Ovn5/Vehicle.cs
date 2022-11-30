using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Ovn5
{
    /// <summary>
    /// The abstract class Vehicle to be used as a base class for any type of vehicle.<br></br>
    /// It cannot be instantiated since it is abstract
    /// </summary>
    public abstract class Vehicle : IVehicle
    {
        [Display(Description = "Vehicle type")]
        public Type type;
        [Display(Description = "A six chars text")]
        protected string registrationNumber = string.Empty;//Get by ID
        [Display(Description = "Vehicle color")]
        protected ConsoleColor ConsoleColor;
        [Display(Description = "Vehicle wheels")]
        protected int numberOfWheels;

        public Vehicle(Type type, string registrationNumber, ConsoleColor color, int numberOfWheels)
        {
            this.type = type;
            this.registrationNumber = registrationNumber;
            ConsoleColor = color;
            this.numberOfWheels = numberOfWheels;

        }
        public enum Type
        {
            Airplane,
            Boat,
            Bus,
            Car,
            Motorcycle
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

        IEnumerator<IVehicle> IEnumerable<IVehicle>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
