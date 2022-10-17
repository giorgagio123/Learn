using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreading.Task4.Threads.Join.Services
{
    internal class CreateThreadService : ICreateThreadService
    {
        public void CreateThreads(int count, Action<object> decrementState)
        {
            if (count != 0)
            {
                var dec = new Thread(() => decrementState(count));
                dec.Start();
                dec.Join();
                CreateThreads(count - 1, decrementState);
            }
        }
    }
}
