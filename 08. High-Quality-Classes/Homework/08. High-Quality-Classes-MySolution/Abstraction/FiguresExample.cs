namespace Abstraction
{
    using System;

    using Abstraction.Figures;

    internal class FiguresExample
    {
        private static void Main()
        {
            var circle = new Circle(5);
            Console.WriteLine(circle);
            var rect = new Rectangle(2, 3);
            Console.WriteLine(rect);
        }
    }
}