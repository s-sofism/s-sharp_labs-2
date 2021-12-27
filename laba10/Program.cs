using System;
using System.Collections.Generic;
using System.Reflection;

namespace laba10
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom("FServices.dll");
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
            {
                //Console.WriteLine(t.Name);
            }

            Type tt = asm.GetType("FileService.FileService`1", true, true);
            Type typeInt = tt.MakeGenericType(typeof(Employee));
            object obj = Activator.CreateInstance(typeInt);
            foreach (var t in typeInt.GetMethods())
            {
                //Console.WriteLine(t.Name);
            }

            MethodInfo ReadFile = typeInt.GetMethod("ReadFile");
            MethodInfo SaveData = typeInt.GetMethod("SaveData");

            Employee oneMore = new Employee("Music", 1);
            Employee Time = new Employee("Sounds", 2);
            Employee We = new Employee("Better", 3);
            Employee Gonna = new Employee("With You", 4);
            Employee Celebrate = new Employee("Babe", 5);
            List<Employee> music = new List<Employee>
            {
                oneMore,
                Time,
                We,
                Gonna,
                Celebrate
            };

            SaveData.Invoke(obj, new object[] { music, "for_the_distant_future.txt" });
            List<Employee> rebornMusic = (List<Employee>)ReadFile.Invoke(obj, new object[] { "for_the_distant_future.txt" });
            foreach (var t in rebornMusic)
            {
                Console.Write($"{t.Name} ");
            }
        }
    }
}
