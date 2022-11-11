//using Ovn2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

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
                //C# Övningssamling - Inkapsling, arv och polymorfism
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\nC# Övningssamling - Inkapsling, arv och polymorfism");

                //3.1) Inkapsling
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\n------------------------");
                Console.WriteLine("3.1) Inkapsling");
                Console.WriteLine("------------------------\n");
                //Create 6 Persons
                Person person3 = new Person("Lisa", "Orre", 50);
                Person person2 = new Person("Olle", "Hjortsen", 6);
                Person person1 = new Person("Pelle", "Svanslös", 6);

                PersonHandler personHandler = new PersonHandler();
                Person person1a = personHandler.CreatePerson(125, "Pelle", "Svanslös", 1.80, 77.5);
                Person person2a = personHandler.CreatePerson(125, "Lisa", "Orre", 1.65, 60.55);
                Person person3a = personHandler.CreatePerson(125, "Olle", "Hjortsten", 2.15, 110.333);

                //Add all persons to a list
                var personList = new List<Person>
                {
                    person1, person2, person3,
                    person1a, person2a, person3a
                };

                //Loop through the list of persons and write to the console
                foreach (var person in personList)
                {
                    if (person.Weight == 0)  //If person was created in Person.cs
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(" The Person was created in Person.cs:\n");
                    }
                    else                //Or the person was created via PersonHelper.cs
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" Person created in PersonHelper.cs:\n");

                    }
                    Console.WriteLine($" Firstname: {person.FName}\n Lastname: {person.LName}\n " +
                    $"Age: {person.Age}\n Height: {person.Height}\n Weight: {person.Weight}\n ");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    personHandler.SetAge(person, 100);
                    Console.WriteLine($"SetAge () was used: {person.FName} {person.LName} new age: {person.Age}\n");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"F: {person1.FName} L: {person1.LName}, " +
                    $"Age: {person1.Age} W: {person1.Weight} H:{person1.Height}");
                Console.WriteLine($"F: {person2.FName} L: {person2.LName}, " +
                    $"Age: {person2.Age} W: {person2.Weight} H:{person2.Height}");
                Console.WriteLine($"F: {person3.FName} L: {person3.LName}, " +
                    $"Age: {person3.Age} W: {person3.Weight} H:{person3.Height}");
                Console.WriteLine($"F: {person1a.FName} L: {person1a.LName}, " +
                   $"Age: {person1a.Age} W: {person1a.Weight} H:{person1a.Height}");
                Console.WriteLine($"F: {person2a.FName} L: {person2a.LName}, " +
                    $"Age: {person2a.Age} W: {person2a.Weight} H:{person2a.Height}");
                Console.WriteLine($"F: {person3a.FName} L: {person3a.LName}, " +
                    $"Age: {person3a.Age} W: {person3a.Weight} H:{person3a.Height}");

            }
            catch (ArgumentException ae)//Exception message handling due to wrong inputs in parameters
            {                           //Thrown from Properties in Person.cs
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

            //3.2) Polymorfism
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n-------------------------");
            Console.WriteLine("3.2) Polymorfism");
            Console.WriteLine("-------------------------\n");

            //Error handling by clases inheriting from the abstract class UserErrors 
            NumericInputError numericInputError = new NumericInputError();
            TextInputError textInputError = new TextInputError();

            var userErrors = new List<UserError>();
            userErrors.Add(numericInputError);
            userErrors.Add(textInputError);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("UserError messages:\n");
            Console.ForegroundColor = ConsoleColor.Red;

            //Loop through the UserErrors and print to the Console
            foreach (var userError in userErrors)
            {
                Console.WriteLine(userError.UEMessage() + "\n");
            }

            //3.3) Arv
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n-------------------------");
            Console.WriteLine("3.3) Arv");
            Console.WriteLine("-------------------------\n");

            Horse horse = new Horse("Horse", 12, 500, true);
            Dog dog = new Dog("Dog", 12, 500, true);
            Hedgehog hedgehog = new Hedgehog("Hedgehog", 12, 500, 300);
            Worm worm = new Worm("Worm", 12, 12, false);
            Bird bird = new Bird("Bird", 12, 1.2, 200);
            Wolf wolf = new Wolf("Wolf", 12, 50, true);
            Wolfman wolfman = new Wolfman("Wolf", 12, 50, false, true);

            var Animals = new List<Animal>();
            Animals.Add(horse);
            Animals.Add(dog);
            Animals.Add(hedgehog);
            Animals.Add(worm);
            Animals.Add(bird);
            Animals.Add(wolf);
            Animals.Add(wolfman);

            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var animal in Animals)
            {
                var castedAnimal = animal as IPerson; //Is the animal implementing IPerson?

                if (castedAnimal != null)
                {
                    Console.WriteLine("castedAnimal.Talk()");
                    Console.WriteLine("IPerson void Talk() below:\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    castedAnimal.Talk();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"animal.Name");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{animal.Name}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"animal.DoSound()");
                Console.ForegroundColor = ConsoleColor.Yellow;
                animal.DoSound();
                Console.WriteLine(string.Empty);
            }

            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("12.Implementera Talk() som skriver ut vad Wolfman säger.\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Wolfman wolfman2 = new Wolfman("Wolfman", 22, 55.7, false, true);
            wolfman2.Talk();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"13.F: Om vi under utvecklingen kommer fram till att samtliga fåglar" +
                $" behöver ett nytt attribut, i vilken klass bör vi lägga det?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nI klassen Bird.");
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"14. F: Om alla djur behöver det nya attributet, " +
                $"vart skulle man lägga det då?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nI klassen Animal.");

            //3.4) Mer polymorfism
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n-------------------------");
            Console.WriteLine("3.4) Mer polymorfism");
            Console.WriteLine("-------------------------\n");

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write
            ("Punkterna nedan är redan implementerade i ovanstående kod" +
            " under ");
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write(" 3.3) Arv\n");
            Console.WriteLine("                                                      " +
                "           ---------\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine
            ("3.Skapa en lista Animals i Program.cs som tar emot djur.\n" +
            "4.Skapa några djur(av olika typ) i din lista.\n" +
            "5.Skriv ut vilka djur som finns i listan med hjälp av en foreach-loop\n" +
            "6.Anropa även Animals Sound() metod i foreach-loopen.\n");

            // Animal.

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("ToDo: Punkterna 8. till 18.");
            Console.ReadKey();//Any key to exit program.
        }
    }
}