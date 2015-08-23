namespace Builder
{
    using Builder.VehicleBuilders;

    /// <summary>
    /// The 'Director' class
    /// </summary>
    internal class Shop
    {
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }
}
