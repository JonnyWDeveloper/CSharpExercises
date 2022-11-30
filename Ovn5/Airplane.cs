namespace Ovn5
{
    /// <summary>
    /// The Airplane class inheriting from its abstract base class Vehicle
    /// </summary>
    internal class Airplane : Vehicle
    {
        private int numberOfEngines;

        public Airplane(Type type, string registrationNumber, ConsoleColor color, int numberOfWheels, int numberOfEngines) : base(type, registrationNumber, color, numberOfWheels)
        {
            this.numberOfEngines = numberOfEngines;
        }
        public int NumberOfEngines
        {
            get => numberOfEngines;
            set => numberOfEngines = value;
        }
    }
}
