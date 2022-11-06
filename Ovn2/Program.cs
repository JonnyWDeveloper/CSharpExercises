using Ovn2;
namespace Ovn2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsuleUI consuleUI = new ConsuleUI();

            do
            {
                consuleUI.ShowMainMenu();
            } 
            while (true);
        }
    }
}