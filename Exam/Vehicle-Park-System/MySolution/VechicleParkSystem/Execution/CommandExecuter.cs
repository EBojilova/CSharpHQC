namespace VechicleParkSystem.Execution
{
    using System;
    using System.Globalization;

    using VechicleParkSystem.Interfaces;
    using VechicleParkSystem.VehicleParkObjects;
    using VechicleParkSystem.Vehicles;

    internal class CommandExecuter
    {
        private VehiclePark VehiclePark { get; set; }

        public string CommandExecute(ICommand command)
        {
            if (command.Name != "SetupPark" && this.VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }

            switch (command.Name)
            {
                case "SetupPark":
                    var sectors = int.Parse(command.Parameters["sectors"]);
                    var placesPerSectors = int.Parse(command.Parameters["placesPerSector"]);
                    this.VehiclePark = new VehiclePark(sectors, placesPerSectors);
                    return "Vehicle park created";
                case "Park":
                    return this.CommandParkReturn(command);
                case "Exit":

                    // Exit {"licensePlate": "CA5555AH", "time": "2015-05-04T11:40:00.0000000", "paid": 100.00}
                    return this.VehiclePark.ExitVehicle(
                        command.Parameters["licensePlate"], 
                        DateTime.Parse(command.Parameters["time"], null, DateTimeStyles.RoundtripKind), 
                        decimal.Parse(command.Parameters["paid"]));
                case "Status":
                    return this.VehiclePark.GetStatus();
                case "FindVehicle":
                    return this.VehiclePark.FindVehicle(command.Parameters["licensePlate"]);
                case "VehiclesByOwner":
                    return this.VehiclePark.FindVehiclesByOwner(command.Parameters["owner"]);
                default:
                    throw new InvalidOperationException("Invalid command");
            }
        }

        private string CommandParkReturn(ICommand command)
        {
            string commandParkReturn = null;
            var licensePlate = command.Parameters["licensePlate"];
            var owner = command.Parameters["owner"];
            var reservedHours = int.Parse(command.Parameters["hours"]);
            var numberOfSector = int.Parse(command.Parameters["sector"]);
            var placesInSector = int.Parse(command.Parameters["place"]);
            var startTime = DateTime.Parse(command.Parameters["time"], null, DateTimeStyles.RoundtripKind);
            switch (command.Parameters["type"])
            {
                case "car":
                    commandParkReturn = this.VehiclePark.InsertCar(
                        new Car(licensePlate, owner, reservedHours), 
                        numberOfSector, 
                        placesInSector, 
                        startTime);
                    break;

                case "motorbike":
                    commandParkReturn = this.VehiclePark.InsertMotorbike(
                        new Motorbike(licensePlate, owner, reservedHours), 
                        numberOfSector, 
                        placesInSector, 
                        startTime);
                    break;

                case "truck":
                    commandParkReturn = this.VehiclePark.InsertTruck(
                        new Truck(licensePlate, owner, reservedHours), 
                        numberOfSector, 
                        placesInSector, 
                        startTime);
                    break;
            }

            return commandParkReturn;
        }
    }
}