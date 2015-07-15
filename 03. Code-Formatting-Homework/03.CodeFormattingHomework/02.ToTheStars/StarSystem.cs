namespace _02.ToTheStars
{
    using System;

    internal class StarSystem
    {
        private string name;

        private double x;

        private double y;

        public StarSystem(string name, double x, double y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.StringCeck(value);
                this.name = value;
            }
        }

        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.ValidateCoordinate(value);
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.ValidateCoordinate(value);
                this.y = value;
            }
        }

        internal void ValidateCoordinate(double coordinate)
        {
            if (coordinate < 0)
            {
                throw new ArgumentOutOfRangeException("value", "Coordinate can not be negative");
            }
        }

        internal void StringCeck(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentNullException("value", "String cannot be null, empty or whitespace.");
            }
        }
    }
}