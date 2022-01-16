namespace Fibonacci
{
    /// <summary>
    /// Interface of Fibonacci Service
    /// </summary>
    public interface IFibonacciService
    {
        /// <summary>
        /// Run a delay and a Fibonacci calculation tasks asynchronous
        /// </summary>
        /// <param name="number">Input Number</param>
        /// <param name="maxDelay">Maximum possible delay of the Delay Task</param>
        /// <returns>FibonacciResponse</returns>
        FibonacciResponse CompareRandomDelayToFibonacciCalculation(int number, int maxDelay);
    }
}
