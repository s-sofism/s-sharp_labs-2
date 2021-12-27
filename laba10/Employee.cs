using System;
using System.Collections.Generic;
using System.Text;

namespace laba10
{
    [Serializable]
    public class Employee
    {
        public string Name;
        public int id;

        public Employee() { }

        public Employee(string name, int id)
        {
            Name = name;
            this.id = id;
        }
    }
}
