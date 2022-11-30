namespace Ovn5
{
    /// <summary>
    ///  Pratar med IUI/UI och IHandler/Handler
    /// </summary>
    internal class Manager<IVehicle>
    {
        private Handler handler = new Handler();
        private UI ui;
        public Manager()
        {

        }
        internal Handler Handler
        {
            get => handler;
            set => handler = value;
        }
        internal UI Ui
        {
            get => ui;
            set => ui = value;
        }
        public void Start()
        {
            ShowUI();
        }
        public void ShowUI()
        {
            ui = new UI();
            ui.GetMainMenu();
        }
        public void PopulateGarage()//TODO: Switch for each and one for all
        {
            GetVehiclesByType(Vehicle.Type.Airplane);
            GetVehiclesByType(Vehicle.Type.Boat);
            GetVehiclesByType(Vehicle.Type.Bus);
            GetVehiclesByType(Vehicle.Type.Car);
            GetVehiclesByType(Vehicle.Type.Motorcycle);
        }
        public void GetVehicles(object type, bool seed)
        {
            handler.GetVehicles((Vehicle.Type)type, seed);
        }
        public void GetVehiclesByType(object type)
        {
            handler.GetVehiclesByType((Vehicle.Type)type);
        }
        public void CreateGarage(int capacity)
        {
            handler.CreateGarage(capacity);
        }
        public void SeedWithVehicles()
        {
            handler.SeedWithVehicles();
        }
        public int GetVehiclesParkedInGarage()
        {
            return handler.GetVehiclesParkedInGarage();
        }
        public void SelectExistingVehicleTypes()
        {
            handler.SelectExistingVehicleTypes();
        }
        public void FindVehicleByProperty(string intType, string property, bool seed)
        {
            handler.FindVehicleByProperty(intType, property, seed);
        }
        public void FindVehicleByRegistration(string registrationNumber, bool seed)
        {
            handler.FindVehicleByRegistration(registrationNumber, seed);
        }
        public void LeaveTheGarage(string registrationNumber)
        {
            handler.LeaveTheGarage(registrationNumber);
        }
        public void ParkInTheGarageVehicle(Vehicle.Type type, string registrationNumber, ConsoleColor color, int numberOfWheels, int uniqueProperty, string brand = "", Fuel fuel = default)
        {
            handler.ParkInTheGarageVehicle(type, registrationNumber, color, numberOfWheels, uniqueProperty, brand);
        }
        public void PrintVehiclesParking(bool seed)
        {
            handler.PrintVehiclesParking(seed);
        }
    }
}
