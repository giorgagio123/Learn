/*
 * 4.	Write a program which recursively creates 10 threads.
 * Each thread should be with the same body and receive a state with integer number, decrement it,
 * print and pass as a state into the newly created thread.
 * Use Thread class for this task and Join for waiting threads.
 * 
 * Implement all of the following options:
 * - a) Use Thread class for this task and Join for waiting threads.
 * - b) ThreadPool class for this task and Semaphore for waiting threads.
 */

using System;
using System.Collections.Generic;
using System.Threading;

namespace MultiThreading.Task4.Threads.Join
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("4.	Write a program which recursively creates 10 threads.");
            Console.WriteLine("Each thread should be with the same body and receive a state with integer number, decrement it, print and pass as a state into the newly created thread.");
            Console.WriteLine("Implement all of the following options:");
            Console.WriteLine();
            Console.WriteLine("- a) Use Thread class for this task and Join for waiting threads.");
            Console.WriteLine("- b) ThreadPool class for this task and Semaphore for waiting threads.");

            Console.WriteLine();
            // feel free to add your code
            var semaphoreObject = new Semaphore(initialCount: 1, maximumCount: 1, name: "CreateThreadsThreadPool");
            CreateThreads(10);
            Console.WriteLine("ThreadPool");
            CreateThreadsThreadPool(10, semaphoreObject);
            Console.ReadLine();
        }

        static void CreateThreads(int count) 
        {
            if (count != 0) 
            {
                var dec = new Thread(() => DecrementState(count));
                dec.Start();
                dec.Join();
                CreateThreads(count -1);
            }
        }

        static void CreateThreadsThreadPool(int count, Semaphore smp)
        {
            if (count != 0)
            {
                smp.WaitOne();
                ThreadPool.QueueUserWorkItem(state => DecrementState((int)state), count);
                smp.Release();
                CreateThreadsThreadPool(count - 1, smp);
            }
        }

        private static void DecrementState(object count)
        {
            Console.WriteLine(count);
        }
    }
}
