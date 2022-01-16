using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fibonacci
{
    /// <summary>
    /// Fibonacci Service class
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

            var taskDelay = Task.Factory.StartNew(() => Task.Delay(_rnd.Next(0, maxDelay)));
            var taskFibo = Task.Factory.StartNew(() => getFibbo(number));

            var tasks = new List<Task>() { taskDelay, taskFibo };

            var firstDone = Task.WhenAny(tasks).Result;

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
