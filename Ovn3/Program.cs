//using Ovn2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace Ovn3
{
    internal class Program
    {
        /// <summary>
        /// Method to extend the default Windows Console Colors
        /// </summary>
        /// <param name="color">Sets the Color of the Console</param>
        /// <returns></returns>
        //static ConsoleColor FromColor(Color color)//ToDo: Check validation numbers of ARGB
        //{                                          //Not working.
        //                                           //It returns the index of ConsoleColor instead of Color.ColorX
        //    int index = (color.R > 128 | color.G > 128 | color.B > 128) ? 8 : 0; // Bright bit
        //    index |= (color.R > 64) ? 4 : 0; // Red bit
        //    index |= (color.G > 64) ? 2 : 0; // Green bit
        //    index |= (color.B > 64) ? 1 : 0; // Blue bit

        //    return (ConsoleColor) index;
        //}

        static void Main(string[] args)
        {
            try
            {
                //TESTING PERSONS
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n//TESTING PERSONS\n");

                //Create 6 Persons
                Person person3 = new Person("Lisa", "Orre", 50);
                Person person2 = new Person("Olle", "Hjortsen", 6);
                Person person1 = new Person("Pelle", "Svanslös", 6);

                PersonHandler personHandler = new PersonHandler();
                Person person1a = personHandler.CreatePerson(125, "Pelle", "Svanslös", 1.80, 77.5);
                Person person2a = personHandler.CreatePerson(125, "Lisa", "Orre", 1.65, 60.55);
                Person person3a = personHandler.CreatePerson(125, "Olle", "Hjortsten", 2.15, 110.333);

                //Add all persons to a list
                var personList = new List<Person>();
                personList.Add(person1);
                personList.Add(person1a);
                personList.Add(person2);
                personList.Add(person2a);
                personList.Add(person3);
                personList.Add(person3a);

                bool switchColor = false;

                //Loop through the list of persons and write to the console
                foreach (var person in personList)
                {                 
                    if (!switchColor)   //If person is created in Person.cs
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        switchColor = true;
                    }
                    else                //Or the person is created via PersonHelper.cs
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        switchColor = false;
                    }
                    Console.WriteLine($" Firstname: {person.FName}\n Lastname: {person.LName}\n " +
                        $"Age: {person.Age}\n Height: {person.Height}\n Weight: {person.Weight}\n ");
                    
                }

                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (ArgumentException ae)//Exception message handling due to wrong inputs in parameters
            {
                int index = 0;
                string[] messages = ae.Message.Split(".");

                foreach (string message in messages)
                {
                    if (messages[index].Equals(message))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();//Any key to exit program.
        }
    }
}