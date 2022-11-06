using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurang
{
    internal class EmployeeRegister
    {
        private Employee employee;
        private List<Employee> employees = new List<Employee>();
        public List<Employee> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;
            }
        }

        public void AddEmployee()
        {
            string firstname = "", lastname = "", currency = "";
            int salaryAmount = 0;
            employee = new Employee(firstname, lastname, currency, salaryAmount);
            Console.WriteLine("");
            Console.WriteLine("Add an employee and the salary in the following steps");
            Console.WriteLine("-----------------------------------------------------" + "\n");
            Console.WriteLine("(Press the key Enter after each step)" + "\n");
            Console.WriteLine("Firstname: ");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Lastname: ");
            employee.LastName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Choose a currency for the salary:" + "\n" + "- SEK for swedish crowns" + "\n" + "- USD for United States dollars, etc." + "\n");
            employee.Currency = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            Console.WriteLine("Enter the salary per month:");
            employee.Amount = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Employee added.");
            Console.WriteLine($"{"Name: " + employee.FirstName + " " + employee.LastName}");
            Console.WriteLine($"{"Salary: " + employee.Currency + " " + employee.Amount}");
            Console.WriteLine("");
            Console.WriteLine("");
            employees.Add(employee);
            Console.WriteLine("List of Employees");
            Console.WriteLine("******************");
            PrintEmployees();
            Console.WriteLine("=================");
            Console.WriteLine("");
        }
        public void PrintEmployees()
        {
            int index = 1;
            foreach (var employee in employees)
            {
                Console.WriteLine($"{index}. {employee.FirstName} {employee.LastName}");
                Console.WriteLine($"{employee.Currency} {employee.Amount}");
                index++;
            }
        }
    }
}
