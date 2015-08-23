namespace AbstractFactory.AbstractPizzaFactories
{
    using System.Collections.Generic;

    using AbstractFactory.PizzaPlaces;

    public class AlfreddosPlace : PizzaFactory
    {
        private const string name = "Alfreddo's Pizza Palace";

        public string Name
        {
            get
            {
                return name;
            }
        }

        public override CheesePizza MakeCheesePizza()
        {
            var ingridients = new List<string>
                                  {
                                      "tomatoes",
                                      "white cheese",
                                      "yellow cheese",
                                      "blue cheese",
                                      "extra smelly cheese"
                                  };

            var pizza = new CheesePizza(ingridients, this.Name);
            return pizza;
        }

        public override Calzone MakeCalzone()
        {
            var ingridients = new List<string> { "tomatoes", "ham", "bacon" };

            var pizza = new Calzone(ingridients, this.Name);
            return pizza;
        }

        public override PepperoniPizza MakePepperoniPizza()
        {
            var ingridients = new List<string> { "tomatoes", "pepperoni", "salami" };

            var pizza = new PepperoniPizza(ingridients, this.Name);
            return pizza;
        }
    }
}