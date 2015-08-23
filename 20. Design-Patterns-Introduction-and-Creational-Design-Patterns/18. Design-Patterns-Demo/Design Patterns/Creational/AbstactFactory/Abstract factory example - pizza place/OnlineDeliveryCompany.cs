﻿namespace AbstractFactory
{
    using AbstractFactory.AbstractPizzaFactories;
    using AbstractFactory.PizzaPlaces;

    public class OnlineDeliveryCompany
    {
        private readonly PizzaFactory factory;

        public OnlineDeliveryCompany(PizzaFactory pizzaFactory)
        {
            this.factory = pizzaFactory;
        }

        public CheesePizza DeliverCheesePizza()
        {
            return this.factory.MakeCheesePizza();
        }

        public Calzone DeliverCalzone()
        {
            return this.factory.MakeCalzone();
        }

        public PepperoniPizza DeliverPepperoniPizza()
        {
            return this.factory.MakePepperoniPizza();
        }
    }
}