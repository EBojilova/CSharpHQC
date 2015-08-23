namespace VechicleParkSystem.VehicleParkObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using VechicleParkSystem.Interfaces;
    using VechicleParkSystem.Vehicles;

    public class VehiclePark : IVehiclePark
    {
        private readonly Data data;

        private readonly Layout layout;

        public VehiclePark(int numberOfSectors, int placesPerSector)
        {
            this.layout = new Layout(numberOfSectors, placesPerSector);
            this.data = new Data(numberOfSectors);
        }

        public string InsertCar(Car car, int numberOfSector, int placesInSector, DateTime startTime)
        {
            return this.InsertVehicle(car, numberOfSector, placesInSector, startTime);
        }

        public string InsertMotorbike(Motorbike motorbike, int numberOfSector, int placesInSector, DateTime startTime)
        {
            return this.InsertVehicle(motorbike, numberOfSector, placesInSector, startTime);
        }

        public string InsertTruck(Truck truck, int numberOfSector, int placesInSector, DateTime startTime)
        {
            return this.InsertVehicle(truck, numberOfSector, placesInSector, startTime);
        }

        ////********************
        ////Motorbike [CA5555AH], owned by Guy Sheard
        ////at place (2,3)
        ////Rate: $2.70
        ////Overtime rate: $0.00
        ////--------------------
        ////Total: $2.70
        ////Paid: $100.00
        ////Change: $97.30
        ////********************
        public string ExitVehicle(string licensePlate, DateTime endTime, decimal money)
        {
            var vehicle = this.data.NumberVehicle.ContainsKey(licensePlate)
                              ? this.data.NumberVehicle[licensePlate]
                              : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            var startTime = this.data.VechicleStartTime[vehicle];
            var hours = (int)Math.Round((endTime - startTime).TotalHours);
            var overtimeHoursCharge = hours > vehicle.ReservedHours
                                          ? (hours - vehicle.ReservedHours) * vehicle.OvertimeRate
                                          : 0;
            var chargePerStay = (vehicle.ReservedHours * vehicle.RegularRate) + overtimeHoursCharge;
            var place = this.data.VehiclePlace[vehicle];

            var ticket = new StringBuilder();
            ticket.AppendLine(new string('*', 20))
                .AppendFormat("{0}", vehicle)
                .AppendLine()
                .AppendFormat("at place {0}", place)
                .AppendLine()
                .AppendFormat("Rate: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate)
                .AppendLine()
                .AppendFormat("Overtime rate: ${0:F2}", overtimeHoursCharge)
                .AppendLine()
                .AppendLine(new string('-', 20))
                .AppendFormat("Total: ${0:F2}", chargePerStay)
                .AppendLine()
                .AppendFormat("Paid: ${0:F2}", money)
                .AppendLine()
                .AppendFormat("Change: ${0:F2}", money - chargePerStay)
                .AppendLine()
                .Append(new string('*', 20));

            this.DeleteVehicleFromPark(place, vehicle);
            return ticket.ToString();
        }

        ////Sector 1: 0 / 5 (0% full)
        ////Sector 2: 0 / 5 (0% full)
        ////Sector 3: 0 / 5 (0% full)
        public string GetStatus()
        {
            var places =
                this.data.OccupiedPlacesPerSectors.Select(
                    (occuipiedPlaces, sectorIndex) =>
                    string.Format(
                        "Sector {0}: {1} / {2} ({3}% full)", 
                        sectorIndex + 1, 
                        occuipiedPlaces, 
                        this.layout.PlacesPerSector, 
                        Math.Round((double)occuipiedPlaces / this.layout.PlacesPerSector * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licensePlate)
        {
            var vehicle = this.data.NumberVehicle.ContainsKey(licensePlate)
                              ? this.data.NumberVehicle[licensePlate]
                              : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            return this.Output(new[] { vehicle });
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (!this.data.OwnerVehicle.ContainsKey(owner))
            {
                return string.Format("No vehicles by {0}", owner);
            }

            var found =
                this.data.OwnerVehicle[owner].OrderBy(v => this.data.VechicleStartTime[v])
                    .ThenByDescending(v => v.LicensePlate);

            return this.Output(found);
        }

        private string Output(IEnumerable<IVehicle> vehicles)
        {
            // Car [CA1111HH], owned by Jay Margareta
            // Parked at (1,2)
            return string.Join(
                Environment.NewLine, 
                vehicles.Select(
                    vehicle =>
                    string.Format(
                        "{0}{1}Parked at {2}", 
                        vehicle.ToString(), 
                        Environment.NewLine, 
                        this.data.VehiclePlace[vehicle])));
        }

        private string InsertVehicle(IVehicle vehicle, int numberOfSector, int placesInSector, DateTime startTime)
        {
            if (numberOfSector > this.layout.Sectors)
            {
                return string.Format("There is no sector {0} in the park", numberOfSector);
            }

            if (placesInSector > this.layout.PlacesPerSector)
            {
                return string.Format("There is no place {0} in sector {1}", placesInSector, numberOfSector);
            }

            if (this.data.Park.ContainsKey(string.Format("({0},{1})", numberOfSector, placesInSector)))
            {
                // The place (1,5) is occupied
                return string.Format("The place ({0},{1}) is occupied", numberOfSector, placesInSector);
            }

            if (this.data.NumberVehicle.ContainsKey(vehicle.LicensePlate))
            {
                // There is already a vehicle with license plate CA1001HH in the park
                return string.Format(
                    "There is already a vehicle with license plate {0} in the park", 
                    vehicle.LicensePlate);
            }

            this.AddVehicleToPark(vehicle, numberOfSector, placesInSector, startTime);
            return string.Format(
                "{0} parked successfully at place ({1},{2})", 
                vehicle.GetType().Name, 
                numberOfSector, 
                placesInSector);
        }

        private void AddVehicleToPark(IVehicle vehicle, int numberOfSector, int placesInSector, DateTime startTime)
        {
            this.data.VehiclePlace[vehicle] = string.Format("({0},{1})", numberOfSector, placesInSector);
            this.data.Park[string.Format("({0},{1})", numberOfSector, placesInSector)] = vehicle;
            this.data.NumberVehicle[vehicle.LicensePlate] = vehicle;
            this.data.VechicleStartTime[vehicle] = startTime;
            this.data.OwnerVehicle[vehicle.Owner].Add(vehicle);
            this.data.OccupiedPlacesPerSectors[numberOfSector - 1]++;
        }

        private void DeleteVehicleFromPark(string place, IVehicle vehicle)
        {
            var sector = int.Parse(place.Split(new[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            this.data.Park.Remove(place);
            this.data.VehiclePlace.Remove(vehicle);
            this.data.NumberVehicle.Remove(vehicle.LicensePlate);
            this.data.VechicleStartTime.Remove(vehicle);
            this.data.OwnerVehicle.Remove(vehicle.Owner, vehicle);
            this.data.OccupiedPlacesPerSectors[sector - 1]--;
        }
    }
}