namespace FactoryMethod
{
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    internal class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }
}