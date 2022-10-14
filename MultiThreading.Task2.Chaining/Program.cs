/*
 * 2.	Write a program, which creates a chain of four Tasks.
 * First Task – creates an array of 10 random integer.
 * Second Task – multiplies this array with another random integer.
 * Third Task – sorts this array by ascending.
 * Fourth Task – calculates the average value. All this tasks should print the values to console.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MultiThreading.Task2.Chaining
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(".Net Mentoring Program. MultiThreading V1 ");
            Console.WriteLine("2.	Write a program, which creates a chain of four Tasks.");
            Console.WriteLine("First Task – creates an array of 10 random integer.");
            Console.WriteLine("Second Task – multiplies this array with another random integer.");
            Console.WriteLine("Third Task – sorts this array by ascending.");
            Console.WriteLine("Fourth Task – calculates the average value. All this tasks should print the values to console");
            Console.WriteLine();

            // feel free to add your code
            Task<int[]> task1 = GetRandomInteger();
            Task<int[]> task2 = await task1.ContinueWith(t =>
            {
                Random random = new Random();
                int[] multiplied = t.Result.Select(x => x * random.Next(9)).ToArray();
                Output(multiplied, "Task2");

                return Task.FromResult(multiplied);
            });
            Task<int[]> task3 = await task2.ContinueWith(t => 
            { 
                var ordered = t.Result.OrderByDescending(o => o).ToArray();
                Output(ordered, "Task3");

                return Task.FromResult(ordered);
            });
            Task<double> task4 = await task2.ContinueWith(t =>
            {
                var sum = t.Result.Sum();
                var avg = ((double)sum) / t.Result.Length;
                Output(new int[] { (int)avg }, "Task4");
                return Task.FromResult(avg);
            });
            Console.ReadLine();
        }

        static Task<int[]> GetRandomInteger() 
        {
            Random random = new Random();
            int[] values = new int[10];

            for (int i = 0; i < 10; ++i)
                values[i] = random.Next(9);

            Output(values, "Task1");

            return Task.FromResult(values);
        }

        static void Output(int[] arr, string taskName)
        {
            Console.WriteLine($"{taskName} Results:");
            foreach (var item in arr)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
