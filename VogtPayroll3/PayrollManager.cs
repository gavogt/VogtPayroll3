using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VogtPayroll3
{
    class PayrollManager
    {
        #region Run
        /// <summary>
        /// The beggining of the application
        /// </summary>
        public void Run()
        {
            Display display = new Display();
            Dictionary<int, Employee> dictionary = new Dictionary<int, Employee>();

            dictionary = display.PrintMenu();
            DisplayEmployeeInformationDictionary(dictionary);


        }
        #endregion region

        #region RemoveUserInDictionary
        /// <summary>
        /// Removes user from the dictionary
        /// </summary>
        /// <param name="dictionary">A dictionary passed in</param>
        /// <param name="empID">The employee ID</param>
        /// <returns>A dictionary</returns>
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
        #endregion

        #region UpdateUserInDictionary
        /// <summary>
        /// Update user in dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary passed in</param>
        /// <param name="empID">Employee ID</param>
        /// <returns>A dictionary</returns>
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
        #endregion

        #region ChangeUserInDictionary
        /// <summary>
        /// Changes user in dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary to pass in</param>
        /// <param name="empID">Employee ID to change</param>
        /// <returns></returns>
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
        #endregion

        #region DisplayEmployeeInformationDictionary
        /// <summary>
        /// Displays employee information from a dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary to pass it</param>
        /// <returns>A dictionary</returns>
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
        #endregion
    }
}
