using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VogtPayroll3
{
    class PayrollManager
    {
        private PayrollConsoleReader payrollConsoleReader;

        public PayrollManager()
        {
            payrollConsoleReader = new PayrollConsoleReader();
        }

        public void Run()
        {
            Display display = new Display();
            List<Employee> empList = new List<Employee>();
            Dictionary<int, Employee> dictionary = new Dictionary<int, Employee>();

            //empList = display.PrintMenu();
            //DisplayEmployeeInformationDictionary(empList);

            dictionary = display.PrintMenu();
            DisplayEmployeeInformationDictionary(dictionary);


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

        public Dictionary<int, Employee> RemoveUserInDictionary(Dictionary<int, Employee> dictionary, int empID)
        {

            Employee employeeTemp = dictionary[empID];

            dictionary.Remove(employeeTemp.EmpID);

            if (dictionary.TryGetValue(employeeTemp.EmpID, out employeeTemp))
            {
                Console.WriteLine($"For key = {employeeTemp.EmpID}, value = {employeeTemp.FirstName}.");
            }
            else
            {
                Console.WriteLine($"Key = {empID} has been removed!");
            }

            return dictionary;

        }
        public Dictionary<int, Employee> UpdateUserInDictionary(Dictionary<int, Employee> dictionary, int empID)
        {
            PayrollConsoleReader payrollConsoleReader = new PayrollConsoleReader();

                try
                {

                    if (dictionary.ContainsKey(empID))
                    {
                        dictionary.Remove(empID, out Employee emp);
                        emp.HoursWorked = payrollConsoleReader.GetHoursWorkedConsole();
                        emp.Payrate = payrollConsoleReader.GetPayrateConsole();
                        Console.WriteLine("Key: " + emp.EmpID);
                        Console.WriteLine("Value: " + emp.FirstName + " " + emp.LastName);
                        dictionary.Add(empID, emp);
                    }
                    else
                    {
                        Console.WriteLine("error!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error {e}");

                }

            return dictionary;
        }

        public Dictionary<int, Employee> ChangeUserInDictionary(Dictionary<int, Employee> dictionary, int empID)
        {

            PayrollConsoleReader payrollConsoleReader = new PayrollConsoleReader();

                try
                {

                    if (dictionary.ContainsKey(empID))
                    {
                        dictionary.Remove(empID, out Employee emp);
                        emp.FirstName = payrollConsoleReader.GetFirstNameConsole();
                        emp.LastName = payrollConsoleReader.GetLastNameConsole();
                        emp.HoursWorked = payrollConsoleReader.GetHoursWorkedConsole();
                        emp.Payrate = payrollConsoleReader.GetPayrateConsole();
                        Console.WriteLine("Key: " + empID);
                        Console.WriteLine("Value: " + emp.FirstName + " " + emp.LastName);
                        dictionary.Add(empID, emp);
                    }
                    else
                    {
                        Console.WriteLine("error!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error {e}");

                }
            

            return dictionary;
        }

        public Dictionary<int, Employee> DisplayEmployeeInformationDictionary(Dictionary<int, Employee> dictionary)
        {


            Console.WriteLine("\nKeys and Values: ");

            foreach (KeyValuePair<int, Employee> employeeKeyValuePair in dictionary)
            {
                try
                {
                    Console.WriteLine("Key: " + employeeKeyValuePair.Key);
                    Employee emp = employeeKeyValuePair.Value;
                    Console.WriteLine("Name: " + emp.FirstName + " " + emp.LastName);
                    Console.WriteLine("Hours worked: " + emp.HoursWorked);
                    Console.WriteLine("Payrate: " + emp.Payrate);

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error {e}");

                }
            }

            return dictionary;

        }

        public Dictionary<int, Employee> AddEmployeeToDictionary(Employee emp)
        {
            var dictionary = new Dictionary<int, Employee>();

            dictionary.Add(emp.EmpID, emp);

            return dictionary;
        }
    }
}
