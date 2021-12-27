using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using HRdepartment.domain;
using Newtonsoft.Json;

namespace HRdepartment.domain
{
    public class Serializer : ISerializer
    {
        public void SerializeByLINQ(IEnumerable<Firm> xxx, string fileName)
        {
            string path = $@"C:\Users\София\DesktopC:\053501_Mahazinnikova_laba9\{fileName}";
            XDocument doc = new XDocument();
            XElement library = new XElement("library");
            doc.Add(library);

            foreach (Firm f in xxx)
            {
                XElement firm = new XElement("firm");
                firm.Add(new XAttribute("name", f.Name));
                XElement department = new XElement("HRDepartment");
                foreach (HRDepartment hrd in f.hrdepartment)
                {
                    department.Add(new XElement("id", hrd.id));
                }

                firm.Add(department);
                doc.Root.Add(firm);
                doc.Save(path);
            }
            Console.WriteLine("Data has been saved to file");
        }

        public void SerializeXML(IEnumerable<Firm> xxx, string fileName)
        {
            string path = $@"C:\Users\София\DesktopC:\053501_Mahazinnikova_laba9\{fileName}";
            XmlSerializer formatter = new XmlSerializer(typeof(List<Firm>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, xxx);
                Console.WriteLine("Data has been saved to file");
            }
        }

        public void SerializeJSON(IEnumerable<Firm> xxx, string fileName)
        {
            string path = $@"C:\Users\София\DesktopC:\053501_Mahazinnikova_laba9\{fileName}";
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter fs = File.CreateText(path))
            {
                serializer.Serialize(fs, xxx);
                Console.WriteLine("Data has been saved to file");
            }
        }

        public IEnumerable<Firm> DeSerializeByLINQ(string fileName)
        {
            string path = $@"C:\Users\София\DesktopC:\053501_Mahazinnikova_laba9\{fileName}";
            XDocument doc = XDocument.Load(path);
            List<Firm> newFirms = new List<Firm>();
            foreach (XElement el in doc.Root.Elements())
            {
                List<HRDepartment> hrd = new List<HRDepartment>();
                XElement ell = el.Element("HRDepartment");
                foreach (XElement atr in ell.Elements())
                {
                    int id = Convert.ToInt32(atr.Value);
                    hrd.Add(new HRDepartment(id));
                }
                Firm firm = new Firm(el.Attribute("name").Value, hrd);
                newFirms.Add(firm);
            }
            Console.WriteLine($"Deserialized");
            return newFirms;
        }

        public IEnumerable<Firm> DeSerializeXML(string fileName)
        {
            string path = $@"C:\Users\София\DesktopC:\053501_Mahazinnikova_laba9\{fileName}";
            XmlSerializer formatter = new XmlSerializer(typeof(List<Firm>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                Console.WriteLine($"Deserialized");
                return (List<Firm>)formatter.Deserialize(fs);
            }
        }

        public IEnumerable<Firm> DeSerializeJSON(string fileName)
        {
            string path = $@"C:\Users\София\DesktopC:\053501_Mahazinnikova_laba9\{fileName}";
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader fs = File.OpenText(path))
            {
                List<Firm> newFirms = (List<Firm>)serializer.Deserialize(fs, typeof(List<Firm>));
                Console.WriteLine($"Deserialized");
                return newFirms;
            }
        }
    }
}