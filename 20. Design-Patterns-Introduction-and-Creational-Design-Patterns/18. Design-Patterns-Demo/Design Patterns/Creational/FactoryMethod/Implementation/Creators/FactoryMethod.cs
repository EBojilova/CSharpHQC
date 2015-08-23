namespace FactoryMethod.Implementation.Creators
{
    using global::FactoryMethod.Implementation.Products;

    public abstract class FactoryMethod
    {
        public abstract Product CreateProduct();
    }
}
