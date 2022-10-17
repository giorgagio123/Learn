using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreading.Task2.Chaining.Services
{
    public interface IOutPutService
    {
        void Output(int[] randomIntegers, string taskName);

        void Output(double average, string taskName);
    }
}
