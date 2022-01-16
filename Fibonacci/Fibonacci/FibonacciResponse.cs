namespace Fibonacci
{
    /// <summary>
    /// Dto class for Fibonacci Response
    /// </summary>
    public class FibonacciResponse
    {
        /// <summary>
        /// Value of the Fibonacci response
        /// </summary>
        public int Fibonacci { get; set; }

        /// <summary>
        /// Name of the task which one was first done
        /// </summary>
        public string FirstDone { get; set; }
    }
}
