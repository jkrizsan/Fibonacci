using System;

namespace Fibonacci
{
    internal class Fibonaccier
    {
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

                callLogic(readFromConsole());

                writeToConsole("Do you wouldl like to Continue? [Y]/[N]");

            } while (readFromConsole().ToUpperInvariant() == "Y");

            writeToConsole($"{nameof(Fibonaccier)} application is Ended");
        }

        static void callLogic(string input)
        {
            writeToConsole(input);
        }

        static void writeToConsole(string message)
            => Console.WriteLine($"{message}{Environment.NewLine}");

        static string readFromConsole()
            => Console.ReadLine();

    }
}
