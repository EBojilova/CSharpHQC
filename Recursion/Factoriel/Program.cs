namespace Factoriel
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("n: ");
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine("{0}! = {1}", n, Factorial(n));
        }

        public static decimal Factorial(int n)
        {
            Console.WriteLine(n);// Lineina struktura
            // The bottom of the recursion
            if (n == 0)
            {
                return 1;
            }

            // Recursive call: the method calls itself// NE E DOBRA PRAKTIKA, tai kato pri po-golemi stoinosti moje da se prepalni steka
            //////0! = 1
            //////1! = 1 = 1.1 = 1.0!
            //////2! = 2.1 = 2.1!
            //////3! = 3.2.1 = 3.2!
            //////4! = 4.3.2.1 = 4.3!
            //////5! = 5.4.3.2.1 = 5.4!
            return n * Factorial(n - 1);
        }
    }
}