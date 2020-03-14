using System;

namespace VogtPayroll3
{
    class Program
    {
        static void Main(string[] args)
        {
            PayrollManager payrollManager = new PayrollManager();
            payrollManager.Run();
        }
    }
}
