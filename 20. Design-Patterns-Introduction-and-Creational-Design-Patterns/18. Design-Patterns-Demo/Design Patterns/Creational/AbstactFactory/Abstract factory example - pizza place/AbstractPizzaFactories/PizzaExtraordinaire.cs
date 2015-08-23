namespace AbstractFactory.AbstractPizzaFactories
{
    using System.Collections.Generic;

    using AbstractFactory.PizzaPlaces;

    public class PizzaExtraordinaire : PizzaFactory
    {
        private const string name = "Pizza Extraordinaire";

        public string Name
        {
            get
            {
                return name;
            }
        }

        public override CheesePizza MakeCheesePizza()
        {
            var ingridients = new List<string> { "rotten tomatoes", "grey cheese", "green cheese" };

            var pizza = new CheesePizza(ingridients, this.Name);
            return pizza;
        }

        public override Calzone MakeCalzone()
        {
            var ingridients = new List<string> { "rotten tomatoes", "greasy ham" };

            var pizza = new Calzone(ingridients, this.Name);
            return pizza;
        }

        public override PepperoniPizza MakePepperoniPizza()
        {
            var ingridients = new List<string> { "old salami", "green tomatoes" };

            var pizza = new PepperoniPizza(ingridients, this.Name);
            return pizza;
        }
    }
}
