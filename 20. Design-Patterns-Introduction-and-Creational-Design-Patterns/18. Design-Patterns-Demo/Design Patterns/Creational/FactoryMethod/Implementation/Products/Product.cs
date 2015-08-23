namespace FactoryMethod.Implementation.Products
{
    public abstract class Product
    {
        protected Product(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}
