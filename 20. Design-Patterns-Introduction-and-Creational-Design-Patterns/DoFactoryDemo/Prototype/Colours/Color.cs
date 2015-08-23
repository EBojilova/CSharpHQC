namespace Prototype.Colours
{
    using System;

    /// <summary>
    /// The 'ConcretePrototype' class
    /// </summary>
    internal class Color : ColorPrototype
    {
        private readonly int blue;

        private readonly int green;

        private readonly int red;

        // Constructor
        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        // Create a shallow copy
        public override ColorPrototype Clone()
        {
            Console.WriteLine("Cloning color RGB: {0,3},{1,3},{2,3}", this.red, this.green, this.blue);

            return this.MemberwiseClone() as ColorPrototype;
        }
    }
}