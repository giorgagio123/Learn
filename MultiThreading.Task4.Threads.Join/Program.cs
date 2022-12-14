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

using MultiThreading.Task4.Threads.Join.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MultiThreading.Task4.Threads.Join
{
    class Program
    {
        private static readonly ICreateThreadService _createThreadService = new CreateThreadService();
        private static readonly ICreateThreadService _createThreadFromThreadPoolService = new CreateThreadFromThreadPoolService();
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
            _createThreadService.CreateThreads(10, DecrementState);
            Console.WriteLine("ThreadPool");

            _createThreadFromThreadPoolService.CreateThreads(10, DecrementState);
            Console.ReadLine();
        }

        private static void DecrementState(object count)
        {
            Console.WriteLine(count);
        }
    }
}
