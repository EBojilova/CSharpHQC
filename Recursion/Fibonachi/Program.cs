namespace Fibonachi
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("n: ");//Darvesna struktura
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(n));
        }

        public static long Fib(int n)
        {
            Console.WriteLine(n);
            if (n <= 2)
            {
                return 1;
            }

            return Fib(n - 1) + Fib(n - 2);
        }
    }
}