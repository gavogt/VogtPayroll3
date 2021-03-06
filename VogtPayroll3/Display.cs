﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VogtPayroll3
{
    class Display
    {
        #region PrintMenu
        /// <summary>
        /// Prints the menu for employee options
        /// </summary>
        /// <returns>A dictionary</returns>
        public Dictionary<int, Employee> PrintMenu()
        {

            char option;
            var empID = 0;
            List<Employee> empList = new List<Employee>();
            PayrollManager payrollManager = new PayrollManager();
            PayrollConsoleReader payrollConsoleReader = new PayrollConsoleReader();
            Dictionary<int, Employee> dictionary = new Dictionary<int, Employee>();

            Console.WriteLine("c. Create a new employee");
            Console.WriteLine("h. Change an employee");
            Console.WriteLine("u. Update an employee");
            Console.WriteLine("d. Delete records");
            Console.WriteLine("q. quit the program");
            option = Console.ReadKey().KeyChar;

            while (option != 'q')
            {
                switch (option)
                {
                    case 'q':
                        System.Environment.Exit(0);
                        break;
                    case 'c':
                        Console.WriteLine("");
                        empID = payrollConsoleReader.GetEmployeeIDConsole();
                        Employee emp = payrollConsoleReader.CreateAnEmployee(empID);
                        dictionary.Add(empID, emp);
                        break;
                    case 'h':
                        empID = payrollConsoleReader.GetEmployeeIDConsole();
                        dictionary = payrollManager.ChangeUserInDictionary(dictionary, empID);
                        break;
                    case 'u':
                        empID = payrollConsoleReader.GetEmployeeIDConsole();
                        dictionary = payrollManager.UpdateUserInDictionary(dictionary, empID);
                        break;
                    case 'd':
                        empID = payrollConsoleReader.GetEmployeeIDConsole();
                        dictionary = payrollManager.RemoveUserInDictionary(dictionary, empID);
                        break;
                    default:
                        Console.WriteLine(" ");
                        Console.WriteLine("please press 'q', 'c', 'h', 'u', 'd'");
                        break;

                }

                option = Console.ReadKey().KeyChar;
                Console.WriteLine("");

            }

            return dictionary;

        }
        #endregion
    }
}
