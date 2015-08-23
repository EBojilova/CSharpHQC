namespace FactoryMethod
{
    using FactoryMethod.Implementation.Products;

    public class Chair : Product
    {
        public Chair(string description)
            : base(description)
        {
        }
    }
}
