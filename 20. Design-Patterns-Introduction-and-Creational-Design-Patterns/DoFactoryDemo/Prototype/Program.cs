namespace Prototype
{
    using System;

    using global::Prototype.Colours;

    /// <summary>
    /// MainApp startup class for Real-World 
    /// Prototype Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            var colormanager = new ColorManager();

            // Initialize with standard colors
            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            // User adds personalized colors
            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);

            // User clones selected colors- celta e da preizpolzvame veche sazdadeni obekti
            var color1 = colormanager["red"].Clone() as Color;
            var color2 = colormanager["peace"].Clone() as Color;
            var color3 = colormanager["flame"].Clone() as Color;

            // Wait for user
            Console.ReadKey();
        }
    }
}