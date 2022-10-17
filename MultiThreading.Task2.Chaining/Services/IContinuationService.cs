using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.Task2.Chaining.Services
{
    public interface IContinuationService
    {
        Task<int[]> MultiplyWithRandomIntegerContinuation(int[] randomIntegers);

        Task<int[]> SortByAscContinuation(int[] randomIntegers);

        Task<double> GetAvarageContinuation(int[] randomIntegers);
    }
}
