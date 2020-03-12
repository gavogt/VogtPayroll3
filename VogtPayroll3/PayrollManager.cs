using System;
using System.Collections.Generic;
using System.Text;

namespace VogtPayroll3
{
    class PayrollManager
    {
        public void Run()
        {
            Employee emp = default;
            Display display = new Display();
            List<Employee> empList = new List<Employee>();

            emp = display.PrintMenu();
            emp.AddEmployeeToList(emp);

        }
    }
}
