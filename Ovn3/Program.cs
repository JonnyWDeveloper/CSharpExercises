//using Ovn2;
using System;
using System.Diagnostics;

namespace Ovn3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //TESTING PERSONS
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n//TESTING PERSONS\n");

                //Create Persons
                Person person3 = new Person("Lisa", "Liljestam", 50);
                Person person2 = new Person("Olle", "Liljekvast", 6);
                PersonHandler personHandler = new PersonHandler();
                Person person1 = personHandler.CreatePerson(125, "Pelle", "Svanslös", 1.80, 77.5);

                //person1 - Created via PersonHandler.cs  
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n//person1 - Created via PersonHandler");

                //BEFORE the SetAge method is used in PersonHandler
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("//person1 BEFORE the SetAge method is used in PersonHandler");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" Firstname: {person1.FName}\n Lastname: {person1.LName}\n " +
                        $"Age: {person1.Age}\n Height: {person1.Height}\n Weight: {person1.Weight}\n ");
                //AFTER the SetAge method is used in PersonHandler
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("//person1 AFTER the SetAge method is used in PersonHandler");
                Console.ForegroundColor = ConsoleColor.Green;
                personHandler.SetAge(person1, 75);
                Console.WriteLine($" Firstname: {person1.FName}\n Lastname: {person1.LName}\n " +
                         $"Age: {person1.Age}\n Height: {person1.Height}\n Weight: {person1.Weight}\n ");

                //person1 & person2 - Created in Person.cs  
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n//person1 & person2 - Created via PersonHandler");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Förnamn: {person3.FName}\nEfternamn: {person3.LName}\nÅlder: {person3.Age}\n" +
                    $"Längd: {person3.Height} \nVikt: {person3.Weight}\n");              
                Console.WriteLine($"Förnamn: {person2.FName}\nEfternamn: {person2.LName}\n" +
                        $"Ålder: {person2.Age}\nLängd: {person2.Height}\nVikt: {person2.Weight}\n");

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