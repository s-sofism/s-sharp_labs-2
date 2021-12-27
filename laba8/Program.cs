using System;
using System.Collections.Generic;
using System.Linq;

namespace laba8
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<Employee> lit = new List<Employee>();
            lit.Add(new Employee { Name = "Arm...." });
            lit.Add(new Employee { Name = "Dfy." });
            lit.Add(new Employee { Name = "Bct.." });
            lit.Add(new Employee { Name = "And..." });
            lit.Add(new Employee { Name = "Abc" });

            var file = new FileService();
            file.SaveData(lit, "fileName");

            List<Employee> lite = new List<Employee>();
            foreach (Employee t in file.ReadFile("newName"))
            {
                Console.WriteLine("-----");
                Console.WriteLine(t.Name);
                lite.Add(t);
            }
            foreach (Employee t in lite)
            {
                Console.WriteLine(t.Name);
            }
            EmployeeComparer comparator = new EmployeeComparer();
            lite = lite
                .OrderBy(t => t, new EmployeeComparer())
                .ToList();
            var res = from t in file.ReadFile("newName")
                      orderby (t, comparator)
                      select t;


            foreach (Employee t in lite)
            {
                Console.WriteLine(t.Name);
            }
            //Console.WriteLine(comparator.Compare(new Employee { Name = "Abc" }, new Employee { Name = "Dfy" }));

        }
    }
}
