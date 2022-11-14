using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Ovn3
{
    internal class PersonHandler
    {
        private const string name = "PersonHandler";
        private int age;
        private string? fName;
        private string? lName;
        private double height;
        private double weight;
        private Person? person;

        public string Name
        {
            get => name;
            
        }

        public override string ToString()
        {
            return Name;          
        }
        public Person CreatePerson(
            int age,
            string fname,
            string lname,
            double height,
            double weight)
        {
            person = new Person(fname, lname, age, height, weight);
            return person;
        }
        public void SetAge(Person pers, int age)
        {
            pers.Age = age;
        }
    }
}
