namespace VechicleParkSystem.Interfaces
{
    using System;

    using VechicleParkSystem.Vehicles;

    /// <summary>
    /// Provides the basic operations required to run a vehicle park.
    /// </summary>
    internal interface IVehiclePark
    {
        /// <summary>
        /// Inserts a car in the Vehicle park.
        /// </summary>
        /// <param name="car">The car to be inserted.</param>
        /// <param name="numberOfSector">Number of the sector number where the car will park.</param>
        /// <param name="placesInSector">Number of the place in the sector, where the car will park.</param>
        /// <param name="startTime">The time of the parking. Used to calculate the price for the stay at the park.</param>
        /// <returns>Returns a success message if the car has been parked successfully. If the requested parking space (sector, place, or both)
        /// is invalid or occupied, or there is already a vehicle with the same license plate number in the park, returns an error message.</returns>
        string InsertCar(Car car, int numberOfSector, int placesInSector, DateTime startTime);

        /// <summary>
        /// Inserts a motorbike in the Vehicle park.
        /// </summary>
        /// <param name="motorbike">The car to be inserted.</param>
        /// <param name="numberOfSector">Number of the sector number where the motorbike will park.</param>
        /// <param name="placesInSector">Number of the place in the sector, where the motorbike will park.</param>
        /// <param name="startTime">The time of the parking. Used to calculate the price for the stay at the park.</param>
        /// <returns>Returns a success message if the motorbike has been parked successfully. If the requested parking space (sector, place, or both)
        /// is invalid or occupied, or there is already a vehicle with the same license plate number in the park, returns an error message.</returns>
        string InsertMotorbike(Motorbike motorbike, int numberOfSector, int placesInSector, DateTime startTime);

        /// <summary>
        /// Inserts a truck in the Vehicle park.
        /// </summary>
        /// <param name="truck">The truck to be inserted.</param>
        /// <param name="numberOfSector">Number of the sector number where the truck will park.</param>
        /// <param name="placesInSector">Number of the place in the sector, where the truck will park.</param>
        /// <param name="startTime">The time of the parking. Used to calculate the price for the stay at the park.</param>
        /// <returns>Returns a success message if the truck has been parked successfully. If the requested parking space (sector, place, or both)
        /// is invalid or occupied, or there is already a vehicle with the same license plate number in the park, returns a notifying message.</returns>
        string InsertTruck(Truck truck, int numberOfSector, int placesInSector, DateTime startTime);

        /// <summary>
        /// Performs all operations required when a vehicle leaves the park. 
        /// Removes the vehicle from the park and prints a parking ticket for the owner.
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle.</param>
        /// <param name="endTime">The time the vehicle is leaving the park. 
        /// Used to calculate the price for the stay at the park.</param>
        /// <param name="amountPaid">The cahrge paid from the customer for the stay.</param>
        /// <returns>Returns the issued parking ticket in a ready to print form. 
        /// If there is no vehicle with the specified license plate number in the park, returns a notifying message.
        /// </returns>
        string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);

        /// <summary>
        /// Displays the current status of the vehicle park - 
        /// how many parking paces are occupied in each of the parking sectors.
        /// </summary>
        /// <returns>Returns a message displaying the number of the occupied places (cout and percentage) in the park.</returns>
        string GetStatus();

        /// <summary>
        /// Finds the vehicle with the specified license plate number in the vehicle park.
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle.</param>
        /// <returns>Returns information about the vehicle and its parking place. If there is no vehicle 
        /// with the specified license plate in the park, returns a notifying message.</returns>
        string FindVehicle(string licensePlate);

        /// <summary>
        /// Finds all vehicles in the park which belong to the specified owner.
        /// </summary>
        /// <param name="owner">The license owner of the vehicle/s to find.</param>
        /// <returns>Lists all vehicles by the specified owner in the parking lot, 
        /// ordered by arrival time (in ascending order) first, and by license plate number (in ascending order) next.
        /// If there are no vehicles by the specified owner, returns a notifying message.
        /// </returns>
        string FindVehiclesByOwner(string owner);
    }
}