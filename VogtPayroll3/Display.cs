using System;
using System.Collections.Generic;
using System.Text;

namespace VogtPayroll3
{
    class Display
    {

        public Employee PrintMenu()
        {
            Employee emp = default;
            char option;

            Console.WriteLine("press 'q' to quit");
            Console.WriteLine("c. Create a new employee");
            Console.WriteLine("h. Change an employee");
            Console.WriteLine("u. Update an employee");
            Console.WriteLine("d. Delete records");
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
            }
            return emp;
        }
    }
}
