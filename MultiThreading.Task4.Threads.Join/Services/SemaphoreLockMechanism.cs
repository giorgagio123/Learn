using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace MultiThreading.Task4.Threads.Join.Services
{
    internal class SemaphoreLockMechanism : ILockMechanism
    {
        private readonly Semaphore smp = new Semaphore(initialCount: 1, maximumCount: 1, name: "CreateThreadsThreadPool");

        public void SemaphoreLock(Action methodTobeLocked)
        {
            smp.WaitOne();
            methodTobeLocked();
            smp.Release();
        }
    }
}
