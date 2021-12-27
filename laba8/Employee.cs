using System;
using System.Collections.Generic;
using System.Text;

namespace laba8
{
    public class Employee
    {
        public int count { get; set; }
        public string Name { get; set; }

        public Employee() { }

        public Employee(int c, string name)
        {
            count = c;
            Name = name;
        }
    }
}
