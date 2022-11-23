using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn5
{
    /// <summary>
    /// The Airplane class inheriting from its abstract base class Vehicle
    /// </summary>
    internal class Airplane : Vehicle
    {
        private int numberOfEngines;

        public Airplane(string registrationNumber, ConsoleColor color, int numberOfWheels, int numberOfEngines) : base(registrationNumber, color, numberOfWheels)
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
