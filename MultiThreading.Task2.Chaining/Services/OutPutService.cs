using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreading.Task2.Chaining.Services
{
    internal class OutPutService : IOutPutService
    {
        public void Output(int[] randomIntegers, string taskName)
        {
            Console.WriteLine($"{taskName} Results:");
            foreach (var randomInteger in randomIntegers)
            {
                Console.WriteLine(randomInteger.ToString());
            }
        }

        public void Output(double average, string taskName)
        {
            Console.WriteLine($"{taskName} Results:");
            Console.WriteLine(average.ToString());
        }
    }
}
