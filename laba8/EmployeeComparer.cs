using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace laba8
{
    class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x.Name.Length > y.Name.Length)
                return 1;
            else if (x.Name.Length < y.Name.Length)
                return -1;
            else
                return 0;
        }
    }
}
