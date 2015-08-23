namespace Cars.Infrastructure
{
    using Cars.Contracts;

    internal class View : IView
    {
        public View(object model = null)
        {
            this.Model = model;
        }

        public object Model { get; private set; }
    }
}