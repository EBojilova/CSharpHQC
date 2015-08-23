namespace FactoryMethod.Implementation.Creators
{
    using global::FactoryMethod.Implementation.Products;

    public class TableCreator : FactoryMethod
    {
        public override Product CreateProduct()
        {
            var table = new Table("A table created by the table creator.");
            return table;
        }
    }
}
