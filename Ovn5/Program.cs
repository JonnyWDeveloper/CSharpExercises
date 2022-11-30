namespace Ovn5
{
    internal class Program
    {
        static void Main()
        {
            //Program Pratar endast med Manager klassen 
            //Manager ---> IUI <--> UI
            //Manager ---> IHandler <--> Handler --> IGarage <--> Garage
            while (true)
            {
                Manager<IVehicle> manager = new Manager<IVehicle>();
                manager.Start();
            }
        }
    }
}