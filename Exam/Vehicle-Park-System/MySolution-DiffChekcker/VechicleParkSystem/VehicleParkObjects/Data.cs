namespace VechicleParkSystem.VehicleParkObjects
{
    using System;
    using System.Collections.Generic;

    using VechicleParkSystem.Interfaces;

    using Wintellect.PowerCollections;

    internal class Data
    {
        public Data(int numberOfSectors)
        {
            this.VehiclePlace = new Dictionary<IVehicle, string>();
            this.Park = new Dictionary<string, IVehicle>();
            this.NumberVehicle = new Dictionary<string, IVehicle>();
            this.VechicleStartTime = new Dictionary<IVehicle, DateTime>();
            this.OwnerVehicle = new MultiDictionary<string, IVehicle>(false);
            this.OccupiedPlacesPerSectors = new int[numberOfSectors];
        }

        public Dictionary<IVehicle, string> VehiclePlace { get; set; }

        public Dictionary<string, IVehicle> Park { get; set; }

        public Dictionary<string, IVehicle> NumberVehicle { get; set; }

        public Dictionary<IVehicle, DateTime> VechicleStartTime { get; set; }

        public MultiDictionary<string, IVehicle> OwnerVehicle { get; set; }

        public int[] OccupiedPlacesPerSectors { get; set; }
    }
}