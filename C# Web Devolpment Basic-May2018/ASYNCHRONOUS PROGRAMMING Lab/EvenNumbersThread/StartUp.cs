namespace EvenNumbersThread
{
    using System;
    using System.Threading;

    class StartUp
    {
        static void Main(string[] args)
        {
            int minNumber = int.Parse(Console.ReadLine());
            int maxNumber =int.Parse(Console.ReadLine());

            var thread = new Thread(() => PrintEvenNumbers(minNumber, maxNumber));
            thread.Start();
            thread.Join();

            Console.WriteLine("Thread finished work");
        }

        private static void PrintEvenNumbers(int minNumber, int maxNumber)
        {
            for (int i = minNumber; i < maxNumber; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
