using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VogtPayroll3
{
    class PayrollManager
    {
        public void Run()
        {
            Display display = new Display();
            List<Employee> empList = new List<Employee>();

            empList = display.PrintMenu();
            DisplayEmployeeInformation(empList);
            AddEmployeeListToDictionary(empList);




        }

        public void DisplayEmployeeInformation(List<Employee> empList)
        {
            foreach (var employee in empList)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Name: " + employee.FirstName + " " + employee.LastName);
                Console.WriteLine("Employee ID: " + employee.EmpID);
                Console.WriteLine("Gross Pay: " + employee.GetGrossPay());
                Console.WriteLine("Deductions: " + employee.GetDeductions());
                Console.WriteLine("Net Pay: " + employee.GetNetPay());
            }
        }

        public Dictionary<int, Employee> AddEmployeeListToDictionary(List<Employee> empList)
        {
            var dictionary = empList.ToDictionary(x => x.EmpID);

            Console.WriteLine("\nKeys and Values: ");

            foreach (KeyValuePair<int, Employee> employeeKeyValuePair in dictionary)
            {
                try
                {
                    
                    Console.WriteLine("Key: "+employeeKeyValuePair.Key);
                    Employee emp = employeeKeyValuePair.Value;
                    Console.WriteLine("Value: "+emp.FirstName + " " + emp.LastName);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error!");
                    e.ToString();
                }
            }

            return dictionary;
        }
    }
}
