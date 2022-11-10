
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn2
{
    /// <summary>
    /// The Console Application User Interface
    /// </summary>
    public class ConsoleUI
    {
        private string currency = " SEK";   //Swedish crowns.
        private string? input;              //User input fron the Console
        private bool courseHeading = true;  //Show only once.
        private string backtoMainMenu = "h";//Back to the main menu.
        private bool isNumber;              //Check to see if user input is a number.
        private int age = 0;                //Sets cinema visitors age

        /// <summary>
        /// The price range for cinema tickets.
        /// </summary>
        enum TicketPrices
        {
            Free = 0,
            Youth = 80,
            Senior = 90,
            Regular = 120
        }
        /// <summary>
        /// Sets the fontcolor of the Console.
        /// </summary>
        /// <param name="color"></param>
        public static void SetFontColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        /// <summary>
        /// Returns all user activity.
        /// </summary>
        /// <returns></returns>
        public string? GetUserInput()
        {
            input = Console.ReadLine();
            return input;
        }
        /// <summary>
        /// Prints information and responds to user input.
        /// </summary>
        /// <param name="message">Different texts for console display</param>
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
        public bool IsNumeric(string value)
        {
            //int age;
            return int.TryParse(GetUserInput(), out age);

        }
        /// <summary>
        /// Shows an error message.
        /// </summary>
        /// <param name="longMessage">Whether the message should be longer.</param>
        public void ShowErrorMessage(bool longMessage)
        {
            SetFontColor(ConsoleColor.Red);

            if (longMessage)
            {
                Print("\nOBS! Inmatningen var felaktig!\nÅter till huvudmenyn!");
            }
            else
            {
                Print("\nOBS! Inmatningen var felaktig!\n");
            }
        }
        /// <summary>
        /// Shows the Main Menu.
        /// </summary>
        public void ShowMainMenu()//Main Menu 
        {
            if (courseHeading) //Show app heading only once.
            {
                SetFontColor(ConsoleColor.Cyan);
                Print("\n\nC# övning - Flöde via loopar och strängmanipulation");
                courseHeading = false;
            }

            SetFontColor(ConsoleColor.Green);
            Print("\n*****************************************\n");
            Print("                Huvudmeny\n");
            Print("*****************************************\n");
            Print("Välj ett menyalternativ:\n");
            Print("1 Bio - Ungdom eller pensionär");
            Print("2 Bio - Totalkostnad");
            Print("3 Upprepa tio gånger");
            Print("4 Det tredje ordet");
            Print("0 Avsluta\n");
            Print("Ditt val: ");

            switch (GetUserInput().Trim())
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
                    ShowErrorMessage(true);
                    ShowMainMenu();
                    break;
            }
        }
        /// <summary>
        /// Shows the cinema ticket price per category of visitor - menu item on the Main Menu.
        /// </summary>
        public void ShowCinemaAge()//MenuItem 1
        {
            do
            {
                SetFontColor(ConsoleColor.Cyan);

                Print("\nBio - Vad kostar biljetten? - Ungdom eller pensionär?");
                Print("Ange din ålder:");

                SetFontColor(ConsoleColor.White);

                isNumber = int.TryParse(GetUserInput(), out age);

                if (isNumber)
                {
                    if (age > 4 && age < 20)
                    {
                        Print("Ungdomspris: 80 kr");
                    }
                    else if (age > 64 && age < 101)
                    {
                        Print("Pensionärspris: 90 kr");
                    }
                    else if (age < 5 || age > 100)
                    {
                        Print("Grattis! Du går in gratis!");
                    }
                    else
                    {
                        Print("Standardpris: 120 kr");
                    }
                }
                else
                {
                    if (Equals(backtoMainMenu, input.ToLower().Trim()))
                    {
                        ShowMainMenu();
                    }
                    else
                    {
                        ShowErrorMessage(false);
                    }
                }
            } while (true);
        }
        /// <summary>
        /// Shows the number of people and the total cost for cinema tickets - menu item on the Main Menu.
        /// </summary>
        public void ShowCinemaPriceTotal()//MenuItem 2
        {
            int total = 0;
            int persons = 0;
            string ticketPrice = "\nBiljettpris: ";

            do
            {
                SetFontColor(ConsoleColor.Cyan);
                Print("\nBio - Vad kostar biobesöket? - Totalkostnad");
                Print("Ange ålder för varje person i sällskapet, en i taget.");
                Print("När du är klar välj H eller h för Huvudmenyn\n");

                SetFontColor(ConsoleColor.White);
                Print("Ålder: ");

                isNumber = int.TryParse(GetUserInput(), out age);

                if (!isNumber)
                {
                    if (Equals(backtoMainMenu, input.ToLower().Trim()))
                    {
                        ShowMainMenu();
                    }
                    else
                    {
                        ShowErrorMessage(false);
                    }
                }
                else
                {
                    if (age < 5 || age > 100) //Up to 4 and from 101
                    {
                        total = total + (int)TicketPrices.Free;
                        Print($"{ticketPrice}{(int)TicketPrices.Free}{currency}");
                        persons += 1;
                    }
                    else if (age > 4 && age < 20) //Youth 5 - 18
                    {
                        total = total + (int)TicketPrices.Youth;
                        Print($"{ticketPrice}{(int)TicketPrices.Youth}{currency}");
                        persons += 1;
                    }
                    else if (age > 64 && age < 101) //Senior citizen 65 - 100
                    {
                        total = total + (int)TicketPrices.Senior;
                        Print($"{ticketPrice}{(int)TicketPrices.Senior}{currency}");
                        persons += 1;
                    }
                    else //Age span 19 - 64                    
                    {
                        total = total + (int)TicketPrices.Regular;
                        Print($"{ticketPrice}{(int)TicketPrices.Regular}{currency}");
                        persons += 1;
                    }

                    Print($"\nAntal person(er): {persons}");
                    Print($"Att betala: {total}{currency}");
                }
            }
            while (true);

        }
        /// <summary>
        /// Shows the loop text - menu item on the Main Menu.
        /// </summary>
        public void ShowRepeatMenuItem()//MenuItem 3
        {
            do
            {
                SetFontColor(ConsoleColor.Cyan);
                Print("\nHär skall du skriva in vad du vill.");
                Print("Din text kommer att skrivas ut 10 gånger i föld.");
                Print("När du är klar välj H eller h för Huvudmenyn\n");
                Print("Din text:");
                SetFontColor(ConsoleColor.White);
                input = GetUserInput();

                if (Equals(backtoMainMenu, input.ToLower().Trim()))
                {
                    isNumber = false;
                    ShowMainMenu();
                }

                Print("");

                for (int i = 0; i < 10; i++)
                {
                    if (i != 9) //Adds a space for aesthetics.
                    {
                        Print($"{i + 1}.  {input}");
                    }
                    else
                    {
                        Print($"{i + 1}. {input}");
                    }
                }
            }
            while (true);
        }
        /// <summary>
        /// Shows the 3rd word from the users input - menu item on the Main Menu.
        /// </summary>
        public void ShowWordMenuItem()//MenuItem 4
        {
            do
            {
                SetFontColor(ConsoleColor.Cyan);
                Print("\nHär skall du skriva in minst 3 valfria ord.");
                Print("Ditt tredje ord kommer att skrivas skrivas ut i grönt.");
                Print("När du är klar välj H eller h för Huvudmenyn\n");
                Print("Dina ord:");
                SetFontColor(ConsoleColor.White);
                input = GetUserInput();
                Print("");

                if (input == string.Empty)
                {
                    ShowErrorMessage(false);
                }
                else if (Equals(backtoMainMenu, input.ToLower().Trim()))
                {
                    isNumber = false;
                    ShowMainMenu();
                }
                else
                {
                    //Implicit string array.
                    //Split on a single character: Empty space.
                    //Remove trailing spaces.
                    var wordArray = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (wordArray.Length < 3) //Check to see that intput contains atleast three words. 
                    {
                        ShowErrorMessage(false);
                        ShowWordMenuItem();
                    }
                    else
                    {
                        int wordCounter = 0;

                        foreach (string word in wordArray)
                        {
                            if (wordCounter == 2 && word == wordArray[2])
                            {
                                SetFontColor(ConsoleColor.Green);
                                Print($"Det tredje ordet: {word}");
                            }
                            else
                            {
                                SetFontColor(ConsoleColor.Gray);
                                Print($"{word}");
                            }
                            wordCounter++;
                        }
                    }
                }
            } while (true);
        }
    }
}