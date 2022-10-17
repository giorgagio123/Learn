/*
 * 5. Write a program which creates two threads and a shared collection:
 * the first one should add 10 elements into the collection and the second should print all elements
 * in the collection after each adding.
 * Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.
 */
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace MultiThreading.Task5.Threads.SharedCollection
{
    class Program
    {
        private static object obj = new object();

        static void Main(string[] args)
        {
            var elements = new List<int>();
            Console.WriteLine("5. Write a program which creates two threads and a shared collection:");
            Console.WriteLine("the first one should add 10 elements into the collection and the second should print all elements in the collection after each adding.");
            Console.WriteLine("Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.");
            Console.WriteLine();

            // feel free to add your code
            Task.Factory.StartNew(() => AddElements(elements));

            Console.ReadLine();
        }

        static Task AddElements(List<int> elements)
        {
            for (int i = 0; i < 10; i++)
            {
                elements.Add(i);
                Console.WriteLine();

                var print = Task.Factory.StartNew(() => {
                    foreach (var item in elements)
                    {
                        Console.Write(item);
                    }
                });

                print.Wait();
            }
            return Task.CompletedTask;
        }
    }
}
