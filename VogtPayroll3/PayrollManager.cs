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

        public Dictionary<int, Employee> RemoveUserInDictionary(List<Employee> empList, int empID)
        {
            var dictionary = empList.ToDictionary(x => x.EmpID);

            Employee employeeTemp = dictionary[empID];

            dictionary.Remove(employeeTemp.EmpID);

            if (dictionary.TryGetValue(employeeTemp.EmpID, out employeeTemp))
            {
                Console.WriteLine($"For key = {employeeTemp.EmpID}, value = {employeeTemp.FirstName}.");
            }
            else
            {
                Console.WriteLine($"Key = {empID} is not found.");
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

        public Dictionary<int, Employee> ChangeUserInDictionary(List<Employee> empList, int empID)
        {

            var dictionary = empList.ToDictionary(x => x.EmpID);

            PayrollConsoleReader payrollConsoleReader = new PayrollConsoleReader();
            Employee employeeTemp = dictionary[empID];

            employeeTemp.FirstName = payrollConsoleReader.GetFirstNameConsole();
            employeeTemp.LastName = payrollConsoleReader.GetLastNameConsole();
            //employeeTemp.EmpID = payrollConsoleReader.GetEmployeeIDConsole();
            employeeTemp.HoursWorked = payrollConsoleReader.GetHoursWorkedConsole();
            employeeTemp.Payrate = payrollConsoleReader.GetPayrateConsole();

            dictionary.Add(employeeTemp.EmpID, employeeTemp);

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
                    Console.WriteLine("Error!");
                    e.ToString();

                }
            }

            return dictionary;

        }

        public Dictionary<int, Employee> AddEmployeeToDictionary(Employee emp)
        {
            var dictionary = new Dictionary<int, Employee>();

            PayrollConsoleReader payrollConsoleReader = new PayrollConsoleReader();

            dictionary.Add(emp.EmpID, emp);

            return dictionary;
        }
    }
}
