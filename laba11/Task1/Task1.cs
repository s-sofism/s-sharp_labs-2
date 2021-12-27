using System;
using System.Diagnostics;

namespace Task1Space
{
    public class Task1
    {
        int check = 1;
        public delegate void res(double res);
        public event res ShowResult;

        public void ResultInf(double res)
        {
            Console.WriteLine($"integral: {res}");
        }
        public void Calculate()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double s = 0;
            double y = 0;

            double step = 0.00000001;
            for (double x = 0; x < 1; x += step)
            {
                y = Math.Sin(x);
                s += y * step;
            }
            ShowResult?.Invoke(s);
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.Elapsed} - {check++}");
        }
    }
}
