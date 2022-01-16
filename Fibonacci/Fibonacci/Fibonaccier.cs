using System;

namespace Fibonacci
{
    internal class Fibonaccier
    {
        static IFibonacciService fibonacciService { get; set; } = new FibonacciService();

        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            writeToConsole($"{nameof(Fibonaccier)} application is Started");

            do
            {
                writeToConsole("Please give me a positive number:");

                string inputStr = readFromConsole();

                int inputNumber;

                if (Int32.TryParse(inputStr, out inputNumber))
                {
                    callLogic(inputNumber);
                }
                else
                {
                    writeToConsole("Your input is not correct.");
                }

                writeToConsole("Do you wouldl like to Continue? [Y]/[N]");

            } while (readFromConsole().ToUpperInvariant() == "Y");

            writeToConsole($"{nameof(Fibonaccier)} application is Ended");
        }

        static void callLogic(int input)
        {
            var result = fibonacciService.CompareRandomDelayToFibonacciCalculation(input, 1000);

            writeToConsole($"Fibbonacci of {input} is {result.Fibonacci}");
            writeToConsole($"{result.FirstDone} task was first done.");
        }

        static void writeToConsole(string message)
            => Console.WriteLine($"{message}{Environment.NewLine}");

        static string readFromConsole()
            => Console.ReadLine();

    }
}
