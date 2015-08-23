namespace Prototype
{
    using System;

    public class Program
    {
        private static void Main()
        {
            var darkTrooper = new Stormtrooper("Dark trooper", 180, 80);
            var anotherDarkTrooper = darkTrooper;
            darkTrooper.Height = 200;

            Console.WriteLine(darkTrooper);
            Console.WriteLine(anotherDarkTrooper);

            var clonedDarkTrooper = darkTrooper.Clone();
            darkTrooper.Height = 1800;

            Console.WriteLine(darkTrooper);
            Console.WriteLine(clonedDarkTrooper);
        }
    }
}