using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn5
{
    /// <summary>
    /// The Motorcycle class inheriting from its abstract base class Vehicle
    /// </summary>
    internal class Motorcycle : Vehicle
    {
        private int cylinderVolume;
        public Motorcycle(string registrationNumber, ConsoleColor color, int numberOfWheels, int cylinderVolume) : base(registrationNumber, color, numberOfWheels)
        {
            this.cylinderVolume = cylinderVolume;
        }
        public int CylinderVolume
        {
            get => cylinderVolume;
            set => cylinderVolume = value;
        }
    }
}
