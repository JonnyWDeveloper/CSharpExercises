namespace Ovn5
{
    /// <summary>
    /// The Car class inheriting from its abstract base class Vehicle
    /// </summary>
    internal class Car : Vehicle
    {
        private Fuel fuel;
        private string brand;
        public Car(Type type, string brand, string registrationNumber, ConsoleColor color, int numberOfWheels, Fuel fuel) : base(type, registrationNumber, color, numberOfWheels)
        {
            this.brand = brand;
            this.fuel = fuel;
        }
        public Fuel Fuel
        {
            get => fuel;
            set => fuel = value;
        }
        public string Brand
        {
            get => brand;
            set => brand = value;
        }
    }
    /// <summary>
    /// The diverse group of available car fuels
    /// </summary>
    public enum Fuel
    {
        Biogas,
        Diesel,
        Ethanol,
        Electricity,
        HVO100, //Renewable Diesel made by hydrotreatment of vegetable oils and/or animal fats. 
        Petrol
    }
}
