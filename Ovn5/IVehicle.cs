namespace Ovn5
{
    public interface IVehicle : IEnumerable<IVehicle>
    {
        public enum Type
        {
            Airplane,
            Boat,
            Bus,
            Car,
            Motorcycle
        }
        ConsoleColor color
        {
            get;
            set;
        }
        int NumberOfWheels
        {
            get;
            set;
        }
        string RegistrationNumber
        {
            get;
            set;
        }
    }
}