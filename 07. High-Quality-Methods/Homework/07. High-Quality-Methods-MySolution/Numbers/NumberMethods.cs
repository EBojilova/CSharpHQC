namespace Numbers
{
    using System;

    internal class NumberMethods
    {
        internal static string NumberToString(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentOutOfRangeException(
                        "number", 
                        "The number should be a digit in the range [0 ... 9].");
            }
        }

        internal static int FindMax(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException("numbers", "Parameter list cannot be empty");
            }

            var max = numbers[0];

            for (var i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        internal static void PrintAsNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }

            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }

            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }
    }
}