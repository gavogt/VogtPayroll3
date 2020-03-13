using System;
using System.Collections.Generic;
using System.Text;

namespace VogtPayroll3
{
    class PayrollManager
    {
        public void Run()
        {
            Employee emp = default;
            Display display = new Display();
            List<Employee> empList = new List<Employee>();

            empList = display.PrintMenu();
            DisplayEmployeeInformation(empList);



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
    }
}
