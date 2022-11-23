
namespace Ovn5
{
    internal class UI : IUI
    {
        public UI()
        {

        //  Huvudmeny...
        //  Undermenyer...
        //  Validering...

        //  Från gränssnittet skall det gå att:
        //  ● Navigera till samtlig funktionalitet från garage via gränssnittet
        //  ● Skapa ett garage med en användar specificerad storlek
        //  ● Det skall gå att stänga av applikationen från gränssnittet
        //  Applikationen skall fel hantera indata på ett robust sätt, så att den inte kraschar vid
        //  felaktig inmatning eller användning.

        }
        public void SetConsoleHeading()
        {
            Console.Title = "C# Övning 5 - Garage 1.0";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nC# Övning 5 - Garage 1.0");
            Console.WriteLine(".......................................\n");
        }
        public void GetMainMenu()
        {

        }
        public void SubMenu()
        {

        }
    }
}
