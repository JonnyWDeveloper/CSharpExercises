
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Ovn3
{
    internal interface IPerson
    {
        void Talk();
    }

    internal class Person : IPerson
    {
        private int age;
        private string ?fName;
        private string ?lName;
        private double height;
        private double weight;
        public Person(string firstname, string lastname)
        {
            FName = firstname;
            LName = lastname;
        }
        public Person(string firstname, string lastname, int age)
        {
            FName = firstname;
            LName = lastname;
            Age = age;
        }
        public Person(string firstname, string lastname, int age, double height)
        {
            FName = firstname;
            LName = lastname;
            Age = age;
            Height = height;
        }
        public Person(string firstname, string lastname, int age, double height, double weight)
        {
            FName = firstname;
            LName = lastname;
            Age = age;
            Height = height;
            Weight = weight;
        }
        public override string ToString()
        {
            return FName + " " + LName;
        }
        public string FName
        {
            get
            {
                return fName!;
            }
            set
            {
                if ((value.Length > 1) && (value.Length < 10))
                {
                    fName = value;
                }
                else
                {
                    string message = $"\nInvalid entry - firstname: {value}. " +
                                     $"\nCorrect entry - Your firstname must consist of 2 to 10 letters!\n";
                    throw new ArgumentException($"{message}", "firstname");
                }
            }
        }
        public string LName
        {
            get
            {
                return lName!;
            }
            set
            {
                if ((value.Length > 3) && (value.Length < 16))
                {
                    lName = value;
                }
                else
                {
                    string message = $"\nInvalid entry - lastname: {value}. " +
                                    $"\nCorrect entry - Your lastname must consist of 3 to 15 letters!\n";
                    throw new ArgumentException($"{message}", "lastname");
                }
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    string message = $"\nInvalid entry - age: {value}. " +
                                    $"\nCorrect entry - Your age must be greater than 0!\n";
                    throw new ArgumentException($"{message}", "age");
                }
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }
        public void Talk()
        {
            throw new NotImplementedException();
        }
    }
}



