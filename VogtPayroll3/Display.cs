using System;
using System.Collections.Generic;
using System.Text;

namespace VogtPayroll3
{
    class Display
    {

        public List<Employee> PrintMenu()
        {
            Employee emp = new Employee("holder", "holder", 1, 1, 1.0m);
            char option;
            List<Employee> empList = new List<Employee>();


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
                        emp = emp.CreateAnEmployee();
                        empList = emp.AddEmployeeToList(emp);
                        break;
                    case 'h':
                        // Change an employee()
                        break;
                    case 'u':
                        // Update an employee()
                        break;
                    case 'd':
                        // DeleteRecords()
                        break;
                    default:
                        Console.WriteLine("please press 'q', 'c', 'h', 'u', 'd'");
                        break;
                }
                

                option = Console.ReadKey().KeyChar;
                Console.WriteLine("");
                
            }
            return empList;
        }
    }
}
