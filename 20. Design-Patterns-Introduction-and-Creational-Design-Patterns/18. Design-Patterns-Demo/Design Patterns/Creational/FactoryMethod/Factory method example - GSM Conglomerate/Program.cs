namespace FactoryMethod
{
    using System;

    using global::FactoryMethod.Manufacturers;
    using global::FactoryMethod.Phones;

    public class Program
    {
        public static void Main()
        {
            Manufacturer pearComp = new PearComputers();
            Manufacturer samunComp = new SamunComputers();

            Gsm firstPhone = pearComp.ManufactureGsm();
            Gsm secondPhone = samunComp.ManufactureGsm();

            PrintGsmInfo(firstPhone);
            firstPhone.Start();

            Console.WriteLine();

            PrintGsmInfo(secondPhone);
            secondPhone.Start();
        }

        public static void PrintGsmInfo(Gsm gsm)
        {
            Console.WriteLine("Phone name: {0}", gsm.Name);
            Console.WriteLine("Height: {0}", gsm.Height);
            Console.WriteLine("Width: {0}", gsm.Width);
            Console.WriteLine("Weight: {0}", gsm.Weight);
            Console.WriteLine("Battery life: {0}", gsm.BatteryLife);
        }
    }
}
