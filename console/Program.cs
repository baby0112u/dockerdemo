using System;
using System.Threading;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World from docker!");
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
