﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public int EmpID { get => _empID; set => _empID = value; }
        public int HoursWorked { get => _hoursWorked; set => _hoursWorked = value; }
        public decimal Payrate { get => _payrate; set => _payrate = value; }

        // CTOR
        public Employee(string firstName, string lastName, int empID, int hoursWorked, decimal payRate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmpID = empID;
            this.HoursWorked = hoursWorked;
            this.Payrate = payRate;

        }

        public Employee CreateAnEmployee()
        {

            string firstName;
            string lastName;
            int empID;
            int hoursWorked;
            decimal payrate;

            PayrollConsoleReader payrollConsoleReader = new PayrollConsoleReader();

            firstName = payrollConsoleReader.GetFirstNameConsole();
            lastName = payrollConsoleReader.GetLastNameConsole();
            empID = payrollConsoleReader.GetEmployeeIDConsole();
            hoursWorked = payrollConsoleReader.GetHoursWorkedConsole();
            payrate = payrollConsoleReader.GetPayrateConsole();

            return new Employee(firstName, lastName, empID, hoursWorked, payrate);

        }

        public decimal GetGrossPay()
        {
            return HoursWorked * Payrate;

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

