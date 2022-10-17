using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreading.Task4.Threads.Join.Services
{
    public interface ILockMechanism
    {
        void SemaphoreLock(Action methodTobeLocked);
    }
}
