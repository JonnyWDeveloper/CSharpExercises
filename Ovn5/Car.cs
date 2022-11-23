using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn5
{
    /// <summary>
    /// The Car class inheriting from its abstract base class Vehicle
    /// </summary>
    internal class Car : Vehicle
    {
        private Fuel fuel;
        public Car(string registrationNumber, ConsoleColor color, int numberOfWheels, Fuel fuel) : base(registrationNumber, color, numberOfWheels)
        {
            this.fuel = fuel;
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
