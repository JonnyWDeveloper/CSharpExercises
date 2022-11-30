namespace Ovn5
{
    /// <summary>
    /// The Bus class inheriting from its abstract base class Vehicle
    /// </summary>
    internal class Bus : Vehicle
    {
        private int seats;
        public Bus(Type type, string registrationNumber, ConsoleColor color, int numberOfWheels, int seats) : base(type, registrationNumber, color, numberOfWheels)
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
