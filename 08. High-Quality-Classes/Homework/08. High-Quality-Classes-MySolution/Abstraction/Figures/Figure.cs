namespace Abstraction.Figures
{
    using Abstraction.Interfaces;

    internal abstract class Figure : IPerimetrCalculatable, ISurfaceCalculatable
    {
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        public override string ToString()
        {
            return string.Format(
                "I am a {0}. My perimeter is {1:f2}. My surface is {2:f2}.", 
                this.GetType().Name.ToLower(), 
                this.CalculatePerimeter(), 
                this.CalculateSurface());
        }
    }
}