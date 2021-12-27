using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace laba8
{
    public class FileService : IFileService
    {
        public IEnumerable<Employee> ReadFile(string fileName)
        {
            string path = @"C:\Users\engen\Desktop\dumpster\isp\labs\laba8\" + fileName + ".txt";
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {

                while (reader.PeekChar() > -1)
                {
                    Employee obj = new Employee();
                    obj.Name = reader.ReadString();
                    Console.WriteLine($"Reading: {obj.Name} ");
                    yield return obj;
                }
            }
        }

        public void SaveData(IEnumerable<Employee> data, string fileName)
        {
            string path = @"C:\Users\engen\Desktop\dumpster\isp\labs\laba8\" + fileName + ".txt";
            if (File.Exists(path)) File.Delete(path);
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
            {
                //writer.Seek(0, SeekOrigin.End);
                foreach (Employee t in data)
                {
                    writer.Write(t.Name);
                    Console.WriteLine($"{t.Name} ");
                }
            }

            string newName = "newName";
            string newPath = @"C:\Users\engen\Desktop\dumpster\isp\labs\laba8\" + newName + ".txt";
            if (File.Exists(newPath)) File.Delete(newPath);

            File.Move(path, newPath);
        }
    }
}
