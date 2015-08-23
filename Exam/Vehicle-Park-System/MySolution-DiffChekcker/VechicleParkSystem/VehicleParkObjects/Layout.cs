namespace VechicleParkSystem.VehicleParkObjects
{
    using System;

    internal class Layout
    {
        private int placesPerSector;

        private int sectors;

        public Layout(int numberOfSectors, int placesPerSector)
        {
            this.Sectors = numberOfSectors;
            this.PlacesPerSector = placesPerSector;
        }

        public int Sectors
        {
            get
            {
                return this.sectors;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The number of sectors must be positive.");
                }

                this.sectors = value;
            }
        }

        public int PlacesPerSector
        {
            get
            {
                return this.placesPerSector;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The number of places per sector must be positive.");
                }

                this.placesPerSector = value;
            }
        }
    }
}