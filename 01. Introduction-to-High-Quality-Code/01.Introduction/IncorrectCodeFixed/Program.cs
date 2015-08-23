namespace IncorrectCode
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            ////Formatiran e no ne e korekten
            int value = 010, i = 5, w;
            switch (value)
            {
                case 10:
                    w = 5;
                    Console.WriteLine(w);
                    break;
                case 9:
                    i = 0;
                    break;
                case 8:
                    Console.WriteLine("8 ");
                    break;
                default:
                    Console.WriteLine("def ");
                    {
                        Console.WriteLine("hoho ");
                    }

                    for (var k = 0; k < i; k++, Console.WriteLine(k - 'f'))
                    {
                        ;
                    }

                    break;
            }
            {
                Console.WriteLine("loop!");
            }
        }
    }
}