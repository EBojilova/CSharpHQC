namespace Abstraction.Figures
{
    using System;

    internal class Rectangle : Figure
    {
        private double height;

        private double width;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "width", 
                        "The width of a rectangle should be greater than zero.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("height", "The height of a rectangle should be positive.");
                }

                this.height = value;
            }
        }

        public override double CalculatePerimeter()
        {
            var perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalculateSurface()
        {
            var surface = this.Width * this.Height;
            return surface;
        }
    }
}