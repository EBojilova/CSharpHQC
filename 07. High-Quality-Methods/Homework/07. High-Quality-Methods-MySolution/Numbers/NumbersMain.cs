namespace Numbers
{
    using System;

    internal class NumbersMain
    {
        private static void Main()
        {
            Console.WriteLine(NumberMethods.NumberToString(5));

            Console.WriteLine(NumberMethods.FindMax(5, -1, 3, 2, 14, 2, 3));

            NumberMethods.PrintAsNumber(1.3, "f");
            NumberMethods.PrintAsNumber(0.75, "%");
            NumberMethods.PrintAsNumber(2.30, "r");
        }
    }
}