using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreading.Task4.Threads.Join.Services
{
    public interface ICreateThreadService
    {
        void CreateThreads(int count, Action<object> decrementState);
    }
}
