namespace ExceptionsDemo
{
    using System;

    internal class ExceptionsDemo
    {
        private static void Main()
        {
            var number = Console.ReadLine();

            try
            {
                int.Parse(number);
                Console.WriteLine("You entered valid Int32 number {0}.", number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid integer number!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too big to fit in Int32!");
            }
        }
    }
}