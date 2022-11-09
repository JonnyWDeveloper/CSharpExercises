global using Ovn2;
using System;

namespace Ovn3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI consoleUI= new ConsoleUI();
            ConsoleUI.SetFontColor(ConsoleColor.Green);
            Person person = new Person("Lisa","Liljekvast");
            consoleUI.Print($"Förnamn: {person.FirstName}\nEfternamn: {person.LastName}\nÅlder: {person.Age}\nLängd: {person.Height}\nVikt: {person.Weight}\n");

        }
    }
}