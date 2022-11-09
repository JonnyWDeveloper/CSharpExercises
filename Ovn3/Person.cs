 using Ovn2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ovn3
{
    internal class Person
    {
        public Person(string fname, string lname)
        {
            FirstName = fname;
            LastName = lname;
        }
        private int age;
        private string fName;
        private string lName;
        private int height;
        private int weight;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public string FirstName
        {
            get
            {
                return fName;
            }
            set
            {
                fName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lName;
            }
            set
            {
                lName = value;
            }
        }
        public int Height
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
        public int Weight
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


    }
}
