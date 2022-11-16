
using Microsoft.CSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

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
               Tools.SetFontColor(ConsoleColor.Cyan);
                Tools.Print("\n\nC# Övningssamling - Inkapsling, arv och polymorfism");

                //3.1) Inkapsling
                Tools.SetFontColor( ConsoleColor.Cyan);
                Tools.Print("\n\n--------------------------------------------------------------");
                Tools.Print("3.1) Inkapsling");
                Tools.Print("--------------------------------------------------------------\n");
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
                    Tools.SetFontColor( ConsoleColor.Gray);

                    if (person.Weight == 0)  //If person was created in Person.cs
                    {
                        Tools.Print(" Person created in Person.cs:\n");
                    }
                    else                //Or the person was created via PersonHelper.cs
                    {
                        Tools.Print(" Person created in PersonHelper.cs:\n");
                        Tools.SetFontColor( ConsoleColor.Blue);
                        Tools.Print(personHandler.ToString());
                    }
                    Tools.SetFontColor( ConsoleColor.Yellow);
                    Tools.Print($" Firstname: {person.FName}\n Lastname: {person.LName}\n " +
                    $"Age: {person.Age}\n Height: {person.Height}\n Weight: {person.Weight}\n ");

                    Tools.SetFontColor( ConsoleColor.Gray);
                    personHandler.SetAge(person, 100);
                    Tools.Print($" SetAge () was used: {person.FName} {person.LName} new age: {person.Age}\n");
                }

                Tools.SetFontColor( ConsoleColor.Gray);
                Tools.Print("Resultat:\n");
                Tools.SetFontColor( ConsoleColor.Yellow);
                Tools.Print($"F: {person1.FName} L: {person1.LName}, " +
                    $"Age: {person1.Age} W: {person1.Weight} H:{person1.Height}");
                Tools.Print($"F: {person2.FName} L: {person2.LName}, " +
                    $"Age: {person2.Age} W: {person2.Weight} H:{person2.Height}");
                Tools.Print($"F: {person3.FName} L: {person3.LName}, " +
                    $"Age: {person3.Age} W: {person3.Weight} H:{person3.Height}");
                Tools.Print($"F: {person1a.FName} L: {person1a.LName}, " +
                   $"Age: {person1a.Age} W: {person1a.Weight} H:{person1a.Height}");
                Tools.Print($"F: {person2a.FName} L: {person2a.LName}, " +
                    $"Age: {person2a.Age} W: {person2a.Weight} H:{person2a.Height}");
                Tools.Print($"F: {person3a.FName} L: {person3a.LName}, " +
                    $"Age: {person3a.Age} W: {person3a.Weight} H:{person3a.Height}");


                Tools.SetFontColor( ConsoleColor.DarkMagenta);
                Tools.Print("\nPerson1.toString():");
                Tools.Print(person1.ToString());

            }
            catch (ArgumentException ae)//Exception message handling due to wrong inputs in parameters
            {                           //Thrown from Properties in Person.cs
                int index = 0;
                string[] messages = ae.Message.Split(".");

                foreach (string message in messages)
                {
                    if (messages[index].Equals(message))
                    {
                        Tools.SetFontColor( ConsoleColor.Red);
                    }
                    else
                    {
                        Tools.SetFontColor( ConsoleColor.Green);
                    }
                    Tools.Print(message);
                }
            }
            catch (Exception ex)
            {
                Tools.SetFontColor( ConsoleColor.Red);
                Tools.Print(ex.Message);
            }

            //3.2) Polymorfism
            Tools.SetFontColor( ConsoleColor.Cyan);
            Tools.Print("\n\n--------------------------------------------------------------");
            Tools.Print("3.2) Polymorfism");
            Tools.Print("--------------------------------------------------------------\n");

            //Error handling by clases inheriting from the abstract class UserErrors 
            NumericInputError numericInputError = new NumericInputError();
            TextInputError textInputError = new TextInputError();
            Tools.SetFontColor( ConsoleColor.DarkMagenta);

            var userErrors = new List<UserError>();
            userErrors.Add(numericInputError);
            userErrors.Add(textInputError);

            Tools.SetFontColor( ConsoleColor.Gray);
            Tools.Print("UserError messages:\n");

            //Loop through the UserErrors and print to the Console
            foreach (var userError in userErrors)
            {
                Tools.SetFontColor( ConsoleColor.DarkMagenta);
                if (userError.Equals(numericInputError))
                {
                    Tools.Print(numericInputError.ToString());
                }
                else
                {
                    Tools.Print(textInputError.ToString());

                }
                Tools.SetFontColor( ConsoleColor.Red);
                Tools.Print(userError.UserErrorMessage() + "\n");
            }

            //3.3) Arv
            Tools.SetFontColor(ConsoleColor.Cyan);
            Tools.Print("\n\n---------------------------------------------------------------");
            Tools.Print("3.3) Arv & 3.4) Mer polymorfism");
            Tools.Print("---------------------------------------------------------------\n");

            //3.4) 4.Skapa några djur (av olika typ) i din lista.
            Horse horse = new Horse("Horse", 12, 500, true);
            Dog dog = new Dog("Dog", 12, 500, true);
            Hedgehog hedgehog = new Hedgehog("Hedgehog", 12, 500, 300);
            Worm worm = new Worm("Worm", 12, 12, false);
            Bird bird = new Bird("Bird", 12, 1.2, 200);
            Wolf wolf = new Wolf("Wolf", 12, 50, true);
            Wolfman wolfman = new Wolfman("Wolfman", 12, 50, false, true);

            //3.4) 3. Skapa en lista Animals i Program.cs som tar emot djur.
            var Animals = new List<Animal>();
            Animals.Add(horse);
            Animals.Add(dog);
            Animals.Add(hedgehog);
            Animals.Add(worm);
            Animals.Add(bird);
            Animals.Add(wolf);
            Animals.Add(wolfman);

            Tools.SetFontColor( ConsoleColor.White);

            //3.4) 5. Skriv ut vilka djur som finns i listan med hjälp av en foreach-loop.
            Tools.Print("3.4) 5. Skriv ut vilka djur som finns i listan med hjälp av en foreach-loop.");
            Tools.Print("3.4) 6.Anropa även Animals Sound() metod i foreach-loopen.");
            Tools.Print("3.4) 7.Gör en check i for-loopen ifall ett djur även är av typen IPerson...\n");
            Tools.SetFontColor( ConsoleColor.Gray);
            Tools.Print("Resultat:\n");

            foreach (var animal in Animals)
            {
                var castedAnimal = animal as IPerson;

                Tools.SetFontColor( ConsoleColor.Gray);

                //3.4) 6. Anropa även Animals Sound() metod i foreach-loopen.
                //3.4) 7.Gör en check i for-loopen ifall ett djur även är av typen IPerson...
                if (castedAnimal != null)
                {
                    wolfman = (Wolfman)castedAnimal;
                    Tools.SetFontColor( ConsoleColor.Green);
                    Console.Write($"{animal.GetType().Name}");
                    Tools.Print(" is an IPerson");
                    Tools.SetFontColor( ConsoleColor.Yellow);
                    castedAnimal.Talk();
                }
                else
                {
                    Tools.SetFontColor( ConsoleColor.Green);
                    Tools.Print($"{animal.Name}");
                }

                //3.4) 6. Anropa även Animals Sound() metod i foreach-loopen.
                Tools.SetFontColor( ConsoleColor.Gray);
                Tools.SetFontColor( ConsoleColor.Yellow);
                animal.DoSound();
                Tools.SetFontColor( ConsoleColor.Gray);
                Tools.Print(string.Empty);
            }

            Tools.Print(string.Empty);
            Tools.SetFontColor( ConsoleColor.White);
            Tools.Print("3.3) 12.Implementera Talk() som skriver ut vad Wolfman säger.\n");

            //Single call to Wolfman Talk()
            Tools.SetFontColor( ConsoleColor.Green);
            Wolfman wolfman2 = new Wolfman("Wolfman", 22, 55.7, false, true);
            wolfman2.Talk();

            Tools.SetFontColor( ConsoleColor.White);
            Tools.Print($"3.3) 13.F: Om vi under utvecklingen kommer fram till att samtliga fåglar" +
                $" behöver ett nytt attribut, i vilken klass bör vi lägga det?");
            Tools.SetFontColor( ConsoleColor.Green);
            Tools.Print("\nSvar: I klassen Bird.");
            Tools.Print(string.Empty);
            Tools.SetFontColor( ConsoleColor.White);
            Tools.Print($"3.3) 14. F: Om alla djur behöver det nya attributet, " +
                $"vart skulle man lägga det då?");
            Tools.SetFontColor( ConsoleColor.Green);
            Tools.Print("\nSvar: I klassen Animal.\n");

            //3.4) 8. Skapa en lista för hundar.
            Dog dog1 = new Dog("German Shepard", 7, 12, true);
            Dog dog2 = new Dog("Alaskan Malamute", 15, 24, true);
            Dog dog3 = new Dog("American Leopard Hound", 14, 11, true);
            var dogs = new List<Dog>();
            dogs.Add(dog1);
            dogs.Add(dog2);
            dogs.Add(dog3);
            //dogs.Add(horse); Genererar typfel.

            Tools.SetFontColor( ConsoleColor.White);
            Tools.Print("3.4) 9.F: Försök att lägga till en häst i listan av hundar.Varför fungerar inte det ?");
            Tools.SetFontColor( ConsoleColor.Green);
            Tools.Print("\nSvar: Horse är inte en Dog utan en Animal (Is an Animal - Single Inheritance)\n");
            Tools.SetFontColor( ConsoleColor.White);
            Tools.Print("3.4) 10. F: Vilken typ måste listan vara för att alla klasser skall kunna lagras tillsammans?");
            Tools.SetFontColor( ConsoleColor.Green);
            Tools.Print("\nSvar: Listan måste vara av alla djurs minsta gemensamma nämnare, Animal (Is an Animal - Base Class)\n");

            Tools.SetFontColor( ConsoleColor.White);
            Tools.Print("3.4) 11. Skriv ut samtliga Animals Stats() genom en foreach loop.\n");
            Tools.Print("Resultat:\n");
            Tools.SetFontColor( ConsoleColor.Yellow);
            foreach (var animal in Animals)
            {
                Tools.Print(animal.Stats());// = Animal properties               
            }
            Tools.Print(string.Empty);

            Tools.SetFontColor( ConsoleColor.White);
            Tools.Print("3.4) 13. F: Förklara vad det är som händer.\n");
            Tools.SetFontColor( ConsoleColor.Green);
            Tools.Print("Svar: Alla djurs egenskaper skrivs ut via basklassen, " +
                "varje djur lägger till en egen, unik, egenskap.\n");

            Tools.SetFontColor( ConsoleColor.White);
            Tools.Print("3.4) 14. Skriv ut Stats() metoden enbart för alla hundar genom en foreach på Animals.");

            //Throw in some more dogs in Animals
            Animals.Add(dog1);
            Animals.Add(dog2);
            Animals.Add(dog3);

            Tools.Print("3.4) 18. Hitta ett sätt att skriva ut din nya metod för dog genom en foreach på Animals.\n");

            Tools.SetFontColor( ConsoleColor.Green);
            foreach (var animal in Animals)
            {
                var castedAnimal = animal as Dog;
                //int items = Animals.Count;
                //Tools.Print($"{items}");

                if (castedAnimal != null)
                {
                    Tools.SetFontColor( ConsoleColor.Gray);
                    Tools.Print($"castedAnimal.Stats()");
                    Tools.SetFontColor( ConsoleColor.Green);
                    Tools.Print($"{castedAnimal.Stats()}\n");
                    Tools.SetFontColor( ConsoleColor.Gray);
                    Tools.Print("animal.WalkTheDog()");
                    Tools.SetFontColor( ConsoleColor.Yellow);
                    Tools.Print($"{castedAnimal.WalkTheDog()}\n");
                }
                else
                {   //3.4) 16. Kommer du åt den metoden från Animals listan? 
                    //Svar: Nej!
                    //animal.WalkTheDog(); //Is only accessibly for animals that are dogs.
                    Tools.Print(animal + "\n");
                }
            }

            //Questions
            Tools.SetFontColor( ConsoleColor.White);
            Tools.Print("\n3.4) 15. Skapa en ny metod med valfritt namn i klassen Dog som endast returnerar en valfri sträng.\n");
            Tools.SetFontColor( ConsoleColor.Gray);
            Tools.Print($"dog.WalkTheDog()");
            Tools.SetFontColor( ConsoleColor.Green);
            Tools.Print($"{dog.WalkTheDog()}");

            Tools.SetFontColor( ConsoleColor.White);
            Tools.Print("\n3.4) 16. Kommer du åt den metoden från Animals listan? \n");
            Tools.SetFontColor( ConsoleColor.Gray);
            Tools.Print("animal.WalkTheDog()");
            Tools.SetFontColor( ConsoleColor.Green);
            Tools.Print($"Svar: Nej.");

            Tools.SetFontColor( ConsoleColor.White);
            Tools.Print("\n3.4) 17. F: Varför inte? \n");
            Tools.SetFontColor( ConsoleColor.Green);
            Tools.Print($"Svar: Metoden är endast implementerad i Dog klassen. " +
                $"För att övriga djur ska nå den måste den finnas i Animal klassen.");
            
            Console.ReadKey();//Any key to exit program.
        }
    }
}