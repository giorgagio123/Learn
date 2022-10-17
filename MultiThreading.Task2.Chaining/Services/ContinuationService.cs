using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.Task2.Chaining.Services
{
    internal class ContinuationService : IContinuationService
    {
        const int RandomIntegerInterval = 9;

        private readonly IOutPutService _outPutService;

        public ContinuationService()
        {
            _outPutService = new OutPutService();
        }

        public Task<double> GetAvarageContinuation(int[] randomIntegers)
        {
            var avg = randomIntegers.Average();

            _outPutService.Output(avg, "Task4");

            return Task.FromResult(avg);
        }

        public Task<int[]> MultiplyWithRandomIntegerContinuation(int[] randomIntegers)
        {
            var random = new Random();
            var multiplied = randomIntegers.Select(x => x * random.Next(RandomIntegerInterval)).ToArray();
            _outPutService.Output(multiplied, "Task2");

            return Task.FromResult(multiplied);
        }

        public Task<int[]> SortByAscContinuation(int[] randomIntegers)
        {
            var ordered = randomIntegers.OrderBy(o => o).ToArray();
            _outPutService.Output(ordered, "Task3");

            return Task.FromResult(ordered);
        }
    }
}
