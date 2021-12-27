using System;
using System.Collections.Generic;
using HRdepartment.domain;

namespace _053501_Mahazinnikova_laba9
{
    static public class Program
    {
        static void Main(string[] args)
        {
            List<HRDepartment> HRDEE = new List<HRDepartment>();
            HRDEE.Add(new HRDepartment(1));
            HRDEE.Add(new HRDepartment(2));
            HRDEE.Add(new HRDepartment(3));

            List<HRDepartment> HRDNE = new List<HRDepartment>();
            HRDNE.Add(new HRDepartment(1));
            HRDNE.Add(new HRDepartment(2));
            HRDNE.Add(new HRDepartment(3));

            List<Firm> set = new List<Firm>();
            set.Add(new Firm("StarkIndustries", HRDEE));
            set.Add(new Firm("TommyHalfiger", HRDNE));

            Serializer serializer = new Serializer();
            serializer.SerializeXML(set, "XML.txt");
            serializer.SerializeJSON(set, "JSON.txt");
            serializer.SerializeByLINQ(set, "LINQ.txt");

            foreach (var el in serializer.DeSerializeXML("XML.txt"))
            {
                Console.WriteLine($"Firm name: {el.Name}");
                foreach (var hrd in el.hrdepartment)
                {
                    Console.WriteLine($"HRD:{hrd.id}");
                }
            }

            foreach (var el in serializer.DeSerializeJSON("JSON.txt"))
            {
                Console.WriteLine($"Firm name:{el.Name}");
                foreach (var hrd in el.hrdepartment)
                {
                    Console.WriteLine($"HRD:{hrd.id}");
                }
            }

            foreach (var el in serializer.DeSerializeByLINQ("LINQ.txt"))
            {
                Console.WriteLine($"Firm name:{el.Name}");
                foreach (var hrd in el.hrdepartment)
                {
                    Console.WriteLine($"HRD:{hrd.id}");
                }
            }
        }
    }
}
