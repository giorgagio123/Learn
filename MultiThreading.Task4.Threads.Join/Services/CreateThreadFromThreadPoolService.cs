using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace MultiThreading.Task4.Threads.Join.Services
{
    internal class CreateThreadFromThreadPoolService : ICreateThreadService
    {
        private readonly ILockMechanism lockMechanism = new SemaphoreLockMechanism();
        public void CreateThreads(int count, Action<object> decrementState)
        {
            if (count != 0)
            {
                lockMechanism.SemaphoreLock(() => ThreadPool.QueueUserWorkItem(state => decrementState((int)state), count));
                CreateThreads(count - 1, decrementState);
            }
        }
    }
}
