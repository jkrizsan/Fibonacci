using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fibonacci
{
    /// <summary>
    /// Class of the Fibonacci Service
    /// </summary>
    public class FibonacciService : IFibonacciService
    {
        private Random _rnd;

        public FibonacciService()
        {
            _rnd = new Random();
        }

        /// <inheritdoc />
        public FibonacciResponse CompareRandomDelayToFibonacciCalculation(int number, int maxDelay)
        {
            FibonacciResponse response = new FibonacciResponse();

            Task taskDelay = Task.Factory.StartNew(() => Task.Delay(_rnd.Next(0, maxDelay)));
            Task<int> taskFibo = Task.Factory.StartNew(() => getFibbo(number));

            var tasks = new List<Task>() { taskDelay, taskFibo };

            Task firstDone = Task.WhenAny(tasks).Result;

            Task.WaitAll(tasks.ToArray());
            
            if (tasks[0].Id == firstDone.Id)
            {
                response.FirstDone = "Delay";
            }
            else
            {
                response.FirstDone = "Fibonacci";
            }

            response.Fibonacci = taskFibo.Result;

            return response;
        }

        private int getFibbo(int number)
        {
            if (number == 0 || number == 1)
            {
                return number;
            }

            return getFibbo(number - 1) + getFibbo(number - 2);
        }
    }
}
