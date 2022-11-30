namespace Ovn5
{
    internal interface IHandler : IEnumerable<IHandler>
    {
        Garage<IVehicle> Garage
        {
            get;
            set;
        }

        void Animate(string text, int time);
        void AnimateWord(string text, int time);
        void CreateGarage(int capacity);
        void FindVehicleByRegistration(string registrationNumber, bool seed);
        void GetAirplanes();
        void GetBoats();
        void GetBuses();
        void GetCars();
        IEnumerator<IHandler> GetEnumerator();
        void GetMotorcyles();
        void GetVehiclesByType(Vehicle.Type type);
        int GetVehiclesParkedInGarage();
        void LeaveTheGarage(string registrationNumber);
        void ParkInTheGarageVehicle(Vehicle.Type type, string registrationNumber, ConsoleColor color, int numberOfWheels, int uniqueProperty, string brand = "", Fuel fuel = Fuel.Biogas);
        void PrintVehiclesParking(bool seed);
        void SeedWithVehicles();
        void SelectExistingVehicleTypes();
        void SnippetAnyKeyToExit();
    }
}