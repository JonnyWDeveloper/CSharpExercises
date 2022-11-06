using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn2
{
    internal class ConsuleUI
    {
        private string currency = " SEK";
        private string? input;

        enum TicketPrices
        {
            Free = 0,
            Youth = 80,
            Senior = 90,
            Regular = 120
        }
        public string GetUserInput()
        {
            input = Console.ReadLine()!;
            return input;
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowMainMenu()//Menu 0
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Print("\nC# övning - Flöde via loopar och strängmanipulation\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Print("*****************************************\n");
            Print("                Huvudmeny\n");
            Print("*****************************************\n");
            Print("Välj ett menyalternativ:\n");

            Print("1 Bio - Ungdom eller pensionär");
            Print("2 Bio - Totalkostnad");
            Print("3 Upprepa tio gånger");
            Print("4 Det tredje ordet");
            Print("0 Avsluta\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Print("Ditt val: ");

            switch (GetUserInput())
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    ShowCinemaAge();
                    break;
                case "2":
                    ShowCinemaPriceTotal();
                    break;
                case "3":
                    ShowRepeatMenuItem();
                    break;
                case "4":
                    ShowWordMenuItem();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Print("\nOBS! Inmatningen var felaktig!\nÅter till huvudmenyn!");
                    ShowMainMenu();
                    break;
            }
        }

        public void ShowCinemaAge()//MenuItem 1
        {
            bool isNumber;
            int age = 0;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Print("\nBio - Ungdom eller pensionär");
            Print("Ange din ålder:\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            isNumber = int.TryParse(GetUserInput(), out age);

            if (age > 4 && age < 20)
            {
                Print("\nUngdomspris: 80 kr");
            }
            else if (age > 64 && age < 101)
            {
                Print("\nPensionärspris: 90 kr");
            }
            else if (age < 5 || age > 100)
            {
                Print("\nGrattis! Du går in gratis!");
            }
            else
            {
                Print("\nStandardpris: 120 kr");
            }
        }
        public void ShowCinemaPriceTotal()//MenuItem 2
        {
            bool isNumber;
            int age;
            int total = 0;
            int persons = 0;
            bool run = true;
            string mainMenu = "h";
            string ticketPrice = "\nBiljettpris: ";

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Print("\nBio - Totalkostnad");
                Print("Ange ålder för varje person i sällskapet, en i taget.");
                Print("När du är klar välj h för Huvudmenyn\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Print($"Ålder: ");

                isNumber = int.TryParse(GetUserInput(), out age);

                if (!isNumber)
                {
                    if (String.Equals(mainMenu, input))
                    {
                        ShowMainMenu();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Print("\nOBS! Inmatningen var felaktig!");
                    }
                }
                else
                {
                    if (age < 5 || age > 100) //Up to 4 and from 101
                    {
                        total = total + 0;
                        Print($"{ticketPrice}{(int)TicketPrices.Free}{currency}");
                        persons += 1;
                    }
                    else if (age > 4 && age < 20) //Youth 5 - 18
                    {
                        total = total + 80;
                        Print($"{ticketPrice}{(int)TicketPrices.Youth}{currency}");
                        persons += 1;
                    }
                    else if (age > 64 && age < 101) //Senior citizen 65 - 100
                    {
                        total = total + 90;
                        Print($"{ticketPrice}{(int)TicketPrices.Senior}{currency}");
                        persons += 1;
                    }
                    else //Age span 19 - 64                    
                    {
                        total = total + 120;
                        Print($"{ticketPrice}{(int)TicketPrices.Regular}{currency}");
                        persons += 1;
                    }

                    Print($"\nAntal person(er): {persons}");
                    Print($"Att betala: {total}{currency}");
                }
            }
            while (run);

            Console.ForegroundColor = ConsoleColor.White;

            //ShowMainMenu();
        }
        public void ShowRepeatMenuItem()//MenuItem 3
        {
            Print("\nRepetera x10");
            GetUserInput();
            //ShowMainMenu();
        }
        public void ShowWordMenuItem()//MenuItem 4
        {
            Print("Ange minst 3 ord");
            GetUserInput();
            // ShowMainMenu();
        }
    }
}

