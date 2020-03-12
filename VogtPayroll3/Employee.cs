using System;
using System.Collections.Generic;
using System.Text;

namespace VogtPayroll3
{
    class Employee
    {
        // Fields
        private string _firstName;
        private string _lastName;
        private int _empID;
        private int _hoursWorked;
        private decimal _payrate;
        private const decimal taxAmount = .30m;

        // CTOR
        public Employee(string firstName, string lastName, int empID, int hoursWorked, decimal payRate)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._empID = empID;
            this._hoursWorked = hoursWorked;
            this._payrate = payRate;

        }

        public Employee CreateAnEmployee()
        {

            string firstName;
            string lastName;
            int empID;
            int hoursWorked;
            decimal payrate;

            PayrollConsoleReader payrollConsoleReader = new PayrollConsoleReader();

            Console.WriteLine("What is the first name of the employee?");
            firstName = payrollConsoleReader.GetFirstNameConsole();
            Console.WriteLine("What is the last name of the employee?");
            lastName = payrollConsoleReader.GetLastNameConsole();
            Console.WriteLine("What is the employee id?");
            empID = payrollConsoleReader.GetEmployeeIDConsole();
            Console.WriteLine("How many hours were worked?");
            hoursWorked = payrollConsoleReader.GetHoursWorkedConsole();
            Console.WriteLine("What is the payrate of the employee");
            payrate = payrollConsoleReader.GetPayrateConsole();

            return new Employee(firstName, lastName, empID, hoursWorked, payrate);

        }

        public decimal GetGrossPay()
        {
            return _hoursWorked * _payrate;

        }

        public decimal GetDeductions()
        {
            return GetGrossPay() * taxAmount;

        }

        public decimal GetNetPay()
        {
            return GetGrossPay() - GetDeductions();

        }
    }
}

