namespace Abstraction.Figures
{
    using System;

    internal class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "radius", 
                        "The radius of a circle should be greater than zero.");
                }

                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            var perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            var surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}