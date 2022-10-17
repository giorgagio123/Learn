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
        const int RandomIntegerInterval = 9;

        static void Main(string[] args)
        {
            Console.WriteLine(".Net Mentoring Program. MultiThreading V1 ");
            Console.WriteLine("2.	Write a program, which creates a chain of four Tasks.");
            Console.WriteLine("First Task – creates an array of 10 random integer.");
            Console.WriteLine("Second Task – multiplies this array with another random integer.");
            Console.WriteLine("Third Task – sorts this array by ascending.");
            Console.WriteLine("Fourth Task – calculates the average value. All this tasks should print the values to console");
            Console.WriteLine();

            // feel free to add your code

            var task1 = GetRandomIntegers();
            var task2 = task1.ContinueWith(t => MultiplyWithRandomInteger(t.Result));
            var task3 = task2.ContinueWith(t => SortByAsc(t.Result.Result));
            var task4 = task3.ContinueWith(t => GetAvarage(t.Result.Result));

            Console.ReadLine();
        }

        static Task<int[]> GetRandomIntegers() 
        {
            Random random = new Random();
            var values = new int[10];

            for (int i = 0; i < 10; ++i)
                values[i] = random.Next(9);

            Output(values, "Task1");

            return Task.FromResult(values);
        }

        static Task<int[]> MultiplyWithRandomInteger(int[] array) 
        {
            var random = new Random();
            var multiplied = array.Select(x => x * random.Next(RandomIntegerInterval)).ToArray();
            Output(multiplied, "Task2");

            return Task.FromResult(multiplied);
        }

        static Task<int[]> SortByAsc(int[] array)
        {
            var ordered = array.OrderBy(o => o).ToArray();
            Output(ordered, "Task3");

            return Task.FromResult(ordered);
        }

        static Task<int[]> GetAvarage(int[] array)
        {
            var avg = new int[] { (int)array.Average() } ;

            Output(avg , "Task4");

            return Task.FromResult(avg);
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
