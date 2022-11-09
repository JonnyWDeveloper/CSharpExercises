
namespace Ovn2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI consoleUI = new ConsoleUI();
            do
            {
                consoleUI.ShowMainMenu();
            } 
            while (true);
        }
    }
}