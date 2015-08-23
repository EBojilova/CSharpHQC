namespace FactoryMethod
{
    using System;

    /// <summary>
    /// MainApp startup class for Structural 
    /// Factory Method Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // An array of creators
            var creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            // Iterate over creators and create products
            foreach (var creator in creators)
            {
                var product = creator.FactoryMethod();
                Console.WriteLine("Created {0}", product.GetType().Name);
            }

            // Wait for user
            Console.ReadKey();
        }
    }
}