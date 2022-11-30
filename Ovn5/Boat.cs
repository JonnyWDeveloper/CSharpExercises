namespace Ovn5
{
    internal class Boat : Vehicle
    {
        private int length;
        /// <summary>
        /// Inherits from the abstract class Vehicle.
        /// </summary>
        /// <param name="registrationNumber"></param>
        /// <param name="color"></param>
        /// <param name="length"></param>
        /// <param name="numberOfWheels">Optional: It is possible to use with an Amphibious Boat</param>
        public Boat(Type type, string registrationNumber, ConsoleColor color, int length, int numberOfWheels) : base(type, registrationNumber, color, numberOfWheels)
        {
            this.length = length;
        }
        public int Length
        {
            get => length;
            set => length = value;
        }
    }
}
