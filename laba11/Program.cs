using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Task1Space;
using Task2Space;

namespace laba11
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            Task1 integral = new Task1();
            integral.ShowResult += integral.ResultInf;
            Thread first = new Thread(new ThreadStart(integral.Calculate));
            first.Priority = ThreadPriority.Highest;
            first.Start();

            Thread second = new Thread(new ThreadStart(integral.Calculate));
            second.Priority = ThreadPriority.Lowest;
            second.Start();

            MemoryStream stream = new MemoryStream();
            StreamService service = new StreamService();
            Task firstMethod = service.WriteToStream(stream);
            //Task.WaitAll(firstMethod);
            Task secondMethod = service.CopyFromStream(stream, "MyFile.txt");
            Task.WaitAll(firstMethod, secondMethod);
            Func<AutoShow, bool> checking = AutoShow.Condition;
            Console.WriteLine(await service.GetStatisticsAsync("MyFile.txt", checking));
        }
    }
}
