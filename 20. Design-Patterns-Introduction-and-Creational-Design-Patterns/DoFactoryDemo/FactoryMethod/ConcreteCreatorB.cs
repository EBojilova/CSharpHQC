namespace FactoryMethod
{
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    internal class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}