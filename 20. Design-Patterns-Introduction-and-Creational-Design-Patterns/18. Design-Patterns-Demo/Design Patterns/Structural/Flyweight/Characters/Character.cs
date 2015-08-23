namespace Flyweight.Characters
{
    using System;

    /// <summary>
    /// The 'Flyweight' abstract class
    /// </summary>
    internal abstract class Character
    {
        protected Character(char symbol, int height, int width, int ascent, int desent)
        {
            this.Symbol = symbol;
            this.Height = height;
            this.Width = width;
            this.Ascent = ascent;
            this.Descent = desent;
        }

        public char Symbol { get; private set; }

        public int Ascent { get; private set; }

        public int Descent { get; private set; }

        public int Height { get; private set; }

        public int PointSize { get; private set; }

        public int Width { get; private set; }

        public virtual void Display(int pointSize)
        {
            this.PointSize = pointSize;
            Console.WriteLine("{0} (point size {1})", this.Symbol, this.PointSize);
        }
    }
}