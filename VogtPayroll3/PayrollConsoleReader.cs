using System;
using System.Collections.Generic;
using System.Text;

namespace VogtPayroll3
{
    class PayrollConsoleReader
    {
        #region CreateAnEmployee
        /// <summary>
        /// Creates an employee
        /// </summary>
        /// <param name="empID">The employee ID desired</param>
        /// <returns>An employee object</returns>
        public Employee CreateAnEmployee(int empID)
        {

            string firstName;
            string lastName;
            int hoursWorked;
            decimal payrate;


            PayrollConsoleReader payrollConsoleReader = new PayrollConsoleReader();

            firstName = payrollConsoleReader.GetFirstNameConsole();
            lastName = payrollConsoleReader.GetLastNameConsole();
            hoursWorked = payrollConsoleReader.GetHoursWorkedConsole();
            payrate = payrollConsoleReader.GetPayrateConsole();

            return new Employee(firstName, lastName, empID, hoursWorked, payrate);

        }
        #endregion

        #region GetFirstNameConsole
        /// <summary>
        /// Returns the first name of an employee
        /// </summary>
        /// <returns>First name</returns>
        public string GetFirstNameConsole()
        {
            Console.WriteLine("\nWhat is the first name of the employee?");

            var firstName = Console.ReadLine();

            while (string.IsNullOrEmpty(firstName))
            {
                Console.WriteLine("The first name can't be empty! try again");
                firstName = Console.ReadLine();
            }

            return firstName;

        }
        #endregion

        #region GetLastNameConsole
        /// <summary>
        /// Returns last name of an employee
        /// </summary>
        /// <returns>last name</returns>
        public string GetLastNameConsole()
        {
            Console.WriteLine("What is the last name of the employee?");

            var lastName = Console.ReadLine();

            while (string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("The last name can't be empty! try again");
                lastName = Console.ReadLine();
            }

            return lastName;

        }
        #endregion

        #region GetHoursWorkedConsole
        /// <summary>
        /// Returns hours worked of an employee
        /// </summary>
        /// <returns>Hours worked</returns>
        public int GetHoursWorkedConsole()
        {

            int hoursResult;
            Console.WriteLine("How many hours were worked?");
            var hoursWorked = Console.ReadLine();
            while (!int.TryParse(hoursWorked, out hoursResult))
            {
                Console.WriteLine("Not a number!");
                hoursWorked = Console.ReadLine();
            }

            return hoursResult;

        }
        #endregion

        #region GetEmployeeIDConsole
        /// <summary>
        /// Returns employee ID
        /// </summary>
        /// <returns>Employee ID</returns>
        public int GetEmployeeIDConsole()
        {

            int empIDout;
            Console.WriteLine("What is the employee ID?");
            var empID = Console.ReadLine();
            while (!int.TryParse(empID, out empIDout))
            {
                Console.WriteLine("Not a number!");
                empID = Console.ReadLine();
            }

            return empIDout;

        }
        #endregion

        #region GetPayrateConsole
        /// <summary>
        /// Returns payrate of the employee
        /// </summary>
        /// <returns>Payrate</returns>
        public decimal GetPayrateConsole()
        {
            decimal payrateResult;
            Console.WriteLine("What is the payrate amount?");
            var payrate = Console.ReadLine();
            while (!decimal.TryParse(payrate, out payrateResult))
            {
                Console.WriteLine("Not a payrate amount!");
                payrate = Console.ReadLine();
            }

            return payrateResult;

        }
        #endregion
    }

}
