/*
 * 5. Write a program which creates two threads and a shared collection:
 * the first one should add 10 elements into the collection and the second should print all elements
 * in the collection after each adding.
 * Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.
 */
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace MultiThreading.Task5.Threads.SharedCollection
{
    class Program
    {
        static List<int> elements = new List<int>();
        static AutoResetEvent autoReset = new AutoResetEvent(false);
        static bool producerRunning = true;

        static void Main(string[] args)
        {

            Console.WriteLine("5. Write a program which creates two threads and a shared collection:");
            Console.WriteLine("the first one should add 10 elements into the collection and the second should print all elements in the collection after each adding.");
            Console.WriteLine("Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.");
            Console.WriteLine();

            // feel free to add your code
            var addElements = Task.Factory.StartNew(() => AddElements());
            var printElements = Task.Factory.StartNew(() => PrintElements());

            Task.WaitAll(addElements, printElements);

            Console.ReadLine();
        }

        static Task AddElements()
        {
            for (int i = 0; i < 10; i++)
            {
                autoReset.WaitOne();
                elements.Add(i);
                
            }
            producerRunning = false;
            return Task.CompletedTask;
        }

        static Task PrintElements()
        {
            Console.WriteLine();

            while (producerRunning)
            {
                autoReset.Set();
                Console.WriteLine();
                foreach (var item in elements)
                {
                    Console.Write(item.ToString());
                }
            }

            return Task.CompletedTask;
        }
    }
}
