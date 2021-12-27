using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Task2Space
{
    public class StreamService
    {
        private readonly object locker = new object();

        public StreamService() { }

        public Task WriteToStream(Stream stream)
        {
            return Task.Run(() =>
            {
                lock (locker)
                {
                    Console.WriteLine($"Start writing to stream [{Thread.CurrentThread.ManagedThreadId}]...");
                    StreamWriter sw = new StreamWriter(stream);
                    sw.AutoFlush = true;
                    for (int i = 0; i < 100; i++)
                    {
                        sw.WriteLine($"{i}" + "\nName" + $"{i}" + $"\n{i}");
                    }
                    Console.WriteLine($"End writing to stream [{Thread.CurrentThread.ManagedThreadId}]");
                }
            }
            );
        }

        public Task CopyFromStream(Stream stream, string fileName)
        {
            return Task.Run(() =>
            {
                lock (locker)
                {
                    string path = $@"C:\Users\София\Desktop\laba11\{fileName}";
                    Console.WriteLine($"Start copying from stream [{Thread.CurrentThread.ManagedThreadId}]...");
                    stream.Seek(0, SeekOrigin.Begin);
                    if (File.Exists(path)) File.Delete(path);
                    using (FileStream fileStream = File.Open(path, FileMode.Create))
                    {
                        stream.CopyTo(fileStream);
                    }
                    Console.WriteLine($"End copying from stream [{Thread.CurrentThread.ManagedThreadId}]");
                }
            });
        }

        public async Task<int> GetStatisticsAsync(string filename, Func<AutoShow, bool> filter)
        {
            return await Task.Run(() => GetStatistics(filename, filter));
        }

        public async Task<int> GetStatistics(string fileName, Func<AutoShow, bool> filter)
        {
            string path = $@"C:\Users\София\Desktop\laba11\{fileName}";
            int count = 0;
            Console.WriteLine($"Start get statistic [{Thread.CurrentThread.ManagedThreadId}]...");
            List<AutoShow> autoSet = new List<AutoShow>();
            using (StreamReader streamReader = new StreamReader(File.Open(path, FileMode.Open)))
            {
                for (int i = 0; i < 100; i++)
                {
                    autoSet.Add(new AutoShow(Convert.ToInt32(await streamReader.ReadLineAsync()), await streamReader.ReadLineAsync(), Convert.ToInt32(await streamReader.ReadLineAsync())));
                    if (filter(autoSet[i])) count++;
                    Console.WriteLine(autoSet[i].Name);
                }
            }
            Console.WriteLine($"End geting statistic [{Thread.CurrentThread.ManagedThreadId}]...");
            return count;
        }
    }
}
