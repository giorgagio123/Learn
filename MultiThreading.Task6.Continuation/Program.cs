/*
*  Create a Task and attach continuations to it according to the following criteria:
   a.    Continuation task should be executed regardless of the result of the parent task.
   b.    Continuation task should be executed when the parent task finished without success.
   c.    Continuation task should be executed when the parent task would be finished with fail and parent task thread should be reused for continuation
   d.    Continuation task should be executed outside of the thread pool when the parent task would be cancelled
   Demonstrate the work of the each case with console utility.
*/
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading.Task6.Continuation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create a Task and attach continuations to it according to the following criteria:");
            Console.WriteLine("a.    Continuation task should be executed regardless of the result of the parent task.");
            Console.WriteLine("b.    Continuation task should be executed when the parent task finished without success.");
            Console.WriteLine("c.    Continuation task should be executed when the parent task would be finished with fail and parent task thread should be reused for continuation.");
            Console.WriteLine("d.    Continuation task should be executed outside of the thread pool when the parent task would be cancelled.");
            Console.WriteLine("Demonstrate the work of the each case with console utility.");
            Console.WriteLine();

            // feel free to add your code
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var continuationAexception = Task.Factory.StartNew(() => DoSomethingAndThrowException("Continuation A"), TaskCreationOptions.AttachedToParent).ContinueWith((t) =>
            {
                Console.WriteLine("Failed parent task but still executed continuationA");
            });

            var continuationA = Task.Factory.StartNew(() => DoSomething("Continuation A"), TaskCreationOptions.AttachedToParent).ContinueWith((t) =>
            {
                Console.WriteLine("Succeed parent task but still executed continuationA");
            });

            var continuationBexception = Task.Factory.StartNew(() => DoSomethingAndThrowException("Continuation B"), TaskCreationOptions.AttachedToParent).ContinueWith((t) =>
            {
                Console.WriteLine("Failed parent task but still executed continuationB");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var continuationB = Task.Factory.StartNew(() => DoSomething("Continuation B"), TaskCreationOptions.AttachedToParent).ContinueWith((t) =>
            {
                Console.WriteLine("Succeed parent task but still executed continuationB");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var continuationC = Task.Factory.StartNew(() => DoSomethingAndThrowException("Continuation C")).ContinueWith((t) =>
            {
                Console.WriteLine($"Failed parent task but still executed continuationC. ThreadId - {Thread.CurrentThread.ManagedThreadId}");
            }, (TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously));

            var continuationD = Task.Factory.StartNew(() => DoSomethingAndThrowException("Continuation D"), token).ContinueWith((t) =>
            {
                Console.WriteLine($"Running Continuation D. ThreadId - {Thread.CurrentThread.ManagedThreadId}");
            }, TaskContinuationOptions.OnlyOnCanceled);

            Console.WriteLine("Cancel Continuation D");
            cts.Cancel();

            Console.ReadLine();
        }

        static Task DoSomethingAndThrowException(string option)
        {
            Console.WriteLine($"Task Option - {option}. With Exception. ThreadId - {Thread.CurrentThread.ManagedThreadId}");
            throw new Exception();
        }

        static Task DoSomething(string option)
        {
            Console.WriteLine($"Task Option - {option}. Without Exception. ThreadId - {Thread.CurrentThread.ManagedThreadId}");

            return Task.CompletedTask;
        }
    }
}
