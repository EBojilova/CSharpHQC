namespace CohesionAndCoupling
{
    using System;

    internal class Figure3D
    {
        private double depth;

        private double height;

        private double width;

        public Figure3D(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
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
                    throw new ArgumentOutOfRangeException("width", "The width of a figure should be greater than zero.");
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
                    throw new ArgumentOutOfRangeException(
                        "height", 
                        "The height of a figure should be greater than zero.");
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("depth", "The depth of a figure should be greater than zero.");
                }

                this.depth = value;
            }
        }
    }
}