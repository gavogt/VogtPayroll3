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
        public Dictionary<int, Employee> UpdateUserInDictionary(List<Employee> empList, int empID)
        {
            var dictionary = empList.ToDictionary(x => x.EmpID);

            PayrollConsoleReader payrollConsoleReader = new PayrollConsoleReader();
            Employee employeeTemp = dictionary[empID];

            employeeTemp.HoursWorked = payrollConsoleReader.GetHoursWorkedConsole();
            employeeTemp.Payrate = payrollConsoleReader.GetPayrateConsole();

            dictionary.Add(employeeTemp.EmpID, employeeTemp);

            return dictionary;
        }

        public Dictionary<int, Employee> ChangeUserInDictionary(Dictionary<int, Employee> dictionary)
        {

            PayrollConsoleReader payrollConsoleReader = new PayrollConsoleReader();


            foreach (KeyValuePair<int, Employee> employeeKeyValuePair in dictionary.ToArray())
            {
                try
                {

                    if (dictionary.ContainsKey(employeeKeyValuePair.Key))
                    {
                        dictionary.Remove(employeeKeyValuePair.Key, out Employee emp);
                        emp.FirstName = payrollConsoleReader.GetFirstNameConsole();
                        emp.LastName = payrollConsoleReader.GetLastNameConsole();
                        emp.HoursWorked = payrollConsoleReader.GetHoursWorkedConsole();
                        emp.Payrate = payrollConsoleReader.GetPayrateConsole();
                        Console.WriteLine("Key: " + employeeKeyValuePair.Key);
                        Console.WriteLine("Value: " + emp.FirstName + " " + emp.LastName);
                        dictionary.Add(employeeKeyValuePair.Key, emp);
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
                    Console.WriteLine("Value: " + emp.FirstName + " " + emp.LastName);

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
