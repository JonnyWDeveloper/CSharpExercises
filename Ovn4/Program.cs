using System;
using System.Collections;

namespace Ovn4
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nC# Övningssamling 4 - Minneshantering");
                Console.WriteLine(".......................................\n\n");

                //Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Teori och fakta");
                Console.WriteLine(".......................................\n");

                //Q & A: Questions and answers to Exercise 4.
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Hur fungerar stacken och heapen?\n" +
                    "Förklara gärna med exempel eller skiss på dess grundläggande funktion");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Svar:");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Minnet delas in i två delar: \"The Stack \" och \"The Heap\".\n" +
                    "Stacken lagrar lokala variabler av Value Types och Reference Types.\n" +
                    "Stacken är en wrapper runt en array som är endimensionell.\n" +
                    "Den är bra på att förvara temporär data enligt LIFO (Last In First Out) principen.\n" +
                    "Stacken sköter sin minneshantering själv och raderar variabel referenserna då koden körts i en metod.\n" +
                    "Heapen lagrar instanser av klasser (kopior av objekt) och klassvariablar då de är tilldelade i klassen.\n" +
                    "Referenstypen har endast fått en referens (en sorts pekare) i stacken innan den instansierats.\n" +
                    "Referenstyper får en minnesplats på Heapen efter de har skapats via new operatorn.\n" +
                    "Heapen sköter inte sin minneshantering själv utan den sköts av CLR (Common Language Runtime) GC (Garbage Collector).\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("2.Vad är Value Types repsektive Reference Types och vad skiljer dem åt ?");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Svar:");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Value Types kan vara lokala variablar och huserar då i stacken.\n" +
                    "De kan också finnas i Heapen om de är klassmedlemmar.\n" +
                    "Reference Types (objekt) finns endast i Heapen. Referenserna (pekarna) till objekten finns i Stacken." +
                    "\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("3. Följande metoder ( se bild nedan ) genererar olika svar. " +
                "Den första returnerar 3, den andra returnerar 4, varför?");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Svar:");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("För att x och y är Value Types i första metoden. Det är endast värdet i x som tilldelas y variabeln." +
                    "\nI den andra medtoden finns det två in­stanser av klassen MyInt som är en Reference Type.\n" +
                    "MyInt x refererar till y:s objekt genom tilldelningen x = y.\n" +
                    "När y.MyValue tilldelas 4 så speglas resultatet i x.MyValue som också returnerar 4.\n" +
                    "Det finns nu två referenser till samma MyInt objekt.");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n..............................................................................\n");
                Console.WriteLine("The Main Menu");
                Console.WriteLine("\n..............................................................................");
                //Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPlease navigate through the menu by inputting the number \n(1, 2, 3 , 4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. Check Paranthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nInput: ");
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nPlease enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            List<string> theList = new List<string>();
            string listItem = string.Empty; //Avoiding null reference
            char action = ' '; //The initialization of a char must specify a character.

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(".......................................\n");
                Console.WriteLine("1. Examine a List");
                Console.WriteLine("\n.......................................");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nInstructions:");
                Console.WriteLine("Write a name to add or remove from the list!");
                Console.WriteLine("Use + before the name: +Adam to add or -Adam to remove.");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nInput: ");
                string? input = Console.ReadLine(); //Get user input
                Console.WriteLine();

                if (!string.IsNullOrEmpty(input)    //Input must be atleast 2 chars.
                    && input.Length > 1             //It is not allowed to exit the menu with 0. 
                    && input[0].ToString() != "0"   //and any other character following including more zeros.
                    && input[0].ToString() != "t")  //t calls TrimExcess on the list.
                {
                    listItem = input.Substring(1);  //Get the rest of the characters to add to the list
                                                    //starting from the 2nd character in the string.
                    action = input[0];              // + Add or - Remove symbol.
                }
                else if (!string.IsNullOrEmpty(input) //To exit the menu ONLY 0 is allowed.
                    && input.Length == 1
                    && input[0].ToString() == "0")
                {
                    action = input[0];
                }
                else if (!string.IsNullOrEmpty(input) //To test the TrimExcess method on the List.
                  && input.Length == 1
                  && input[0].ToString() == "t")
                {
                    action = input[0];
                }

                Console.ForegroundColor = ConsoleColor.Green;

                switch (action)
                {
                    case '0':
                        Main();
                        break;
                    case '+':
                        theList.Add($"{listItem}");
                        action = ' '; //Needs to be reset each time otherwise the same input will be added.
                        break;
                    case '-':
                        theList.Remove($"{listItem}");
                        action = ' ';
                        break;
                    case 't':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("--->  Call: Capacity");
                        Console.WriteLine("--->  Call: Count");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("BEFORE - List Capacity:" + theList.Capacity);
                        Console.WriteLine("BEFORE - Count:" + theList.Count + "\n");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("--->  Call: TrimExcess()");
                        theList.TrimExcess();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("AFTER - List Capacity: " + theList.Capacity);
                        Console.WriteLine("AFTER - Count:" + theList.Count + "\n");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Use only + or -");
                        action = ' ';
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--->  Call: foreach (var item in theList)");

                foreach (var element in theList)
                {
                    if (element != string.Empty)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Element: " + element);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("String Empty");
                    }
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nDatastrukturer och minneseffektivitet");
                Console.WriteLine(".......................................\n");
                Console.WriteLine("Q & A - Questions and answers to Exercise 4" +
                    "\nRead the the commented code at the end of the ExamineList() method!\n");
                //Q & A: Questions and answers to Exercise 4.
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.WriteLine("2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek).");
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("Svar:");
                //Console.ForegroundColor = ConsoleColor.DarkGreen;
                //Console.WriteLine(" När listan blir större än nuvarande kapacitet. Count blir större än Capacity.\n");
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.WriteLine("3. Med hur mycket ökar kapaciteten?");
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("Svar:");
                //Console.ForegroundColor = ConsoleColor.DarkGreen;
                //Console.WriteLine("Den fördubblas -> Capacity * 2.\n");
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.WriteLine("4. Varför ökar inte listans kapacitet i samma takt som element läggs till?");
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("Svar:");
                //Console.ForegroundColor = ConsoleColor.DarkGreen;
                //Console.WriteLine("En lista vet inte hur stor den kommer bli." +
                //    "Den måste ändra arrayen dymnamiskt till Capacity storleken.\n" +
                //    "Det blir en kostam operation då varje element måste kopieras.\n" +
                //    "Därför måste den allokera mer minne än den behöver för att minska storleksändrings operationerna.\n");
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.WriteLine("5. Minskar kapaciteten när element tas bort ur listan? ");
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("Svar:");
                //Console.ForegroundColor = ConsoleColor.DarkGreen;
                //Console.WriteLine("Nej.\n");
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.WriteLine("6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?\n");
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("Svar:");
                //Console.ForegroundColor = ConsoleColor.DarkGreen;
                //Console.WriteLine("När man behöver lagra homogena element (av samma datatyp).\n" +
                //   "Om man har relativt stora mängder indexerad data. " +
                //   "Den är snabb att söka på men om man vill göra ändrigar:\n" +
                //   "ta bort och lägga till element så ska man välja List (\"dynamisk array\") istället.\n" +
                //   "Arrayen har ett fast antal platser och går inte att ändra på.\n" +
                //   "Listelement har inget index så man får söka efter elementets plats i listan.\n");
            } while (true);
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(".......................................\n");
                Console.WriteLine("2. Examine a Queue");
                Console.WriteLine("\n.......................................\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Input:   ");

                object? getCurrentPerson = " ";

                //ICA Que
                Console.WriteLine("ICA öppnar - Yippiii!");

                Queue queue = new Queue();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("How many are queuing up (UK) || Lining up (US):  " + queue.Count);

                queue.Enqueue("Kalle");     //Kalle gets in line.

                getCurrentPerson = queue.ToString();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(getCurrentPerson + " has joined the line.");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Who is first in line?  " + queue.Peek());
               
                queue.Enqueue("Greta");     //Greta gets in line.
                getCurrentPerson = queue.ToArray().GetValue(queue.Count - 1);//Gets the current(latest) object in the Queue
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(getCurrentPerson + " has joined the line.");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("How many are queuing up (UK) || Lining up (US):  " + queue.Count);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Who is first in line?  " + queue.Peek());

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(queue.Peek() + " was served and has now left the line.");
                queue.Dequeue();            //Kalle is served and leaves

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("How many are queuing up (UK) || Lining up (US):  " + queue.Count);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Who is first in line?  " + queue.Peek());

                queue.Enqueue("Stina");
                getCurrentPerson = queue.ToString();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(getCurrentPerson + " has joined the line.");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("How many are queuing up (UK) || Lining up (US):  " + queue.Count);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(queue.Peek() + " was served and has now left the line.");
                queue.Dequeue();            //Greta is served and leaves.

                queue.Enqueue("Olle");
                getCurrentPerson = queue.ToString();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(getCurrentPerson + " has joined the line.");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("How many are queuing up (UK) || Lining up (US):  " + queue.Count);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Who is first in line?  " + queue.Peek());

                foreach (var person in queue)
                {
                    Console.WriteLine(person);
                    Console.WriteLine("Count: " + queue.Count);
                }

                string? input = Console.ReadLine(); //Get user input
                if (input != null)
                {

                }
            } while (true);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(".......................................\n");
                Console.WriteLine("3. Examine a Stack");
                Console.WriteLine("\n.......................................\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Input:   ");
                string? input = Console.ReadLine(); //Get user input

                if (input != null)
                {

                }
            } while (true);
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(".......................................\n");
                Console.WriteLine("4. Check Paranthesis");
                Console.WriteLine("\n.......................................\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Input:   ");
                string? input = Console.ReadLine(); //Get user input

                if (input != null)
                {

                }
            } while (true);
        }

    }
}

