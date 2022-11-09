using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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