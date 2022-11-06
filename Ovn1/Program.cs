namespace Restaurang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeRegister employeeRegister = new EmployeeRegister();
            do
            {
                employeeRegister.AddEmployee();
            }
            while (true);
            Environment.Exit(0);    
            //employeeRegister.PrintEmployees();
        }
    }
}