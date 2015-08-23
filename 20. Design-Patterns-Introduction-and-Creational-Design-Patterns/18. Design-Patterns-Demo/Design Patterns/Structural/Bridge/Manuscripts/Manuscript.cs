namespace Bridge.Manuscripts
{
    internal abstract class Manuscript
    {
        /// <summary>
        /// Brige- depends on IFormatter
        /// </summary>
        protected readonly IFormatter Formatter;

        protected Manuscript(IFormatter formatter)
        {
            this.Formatter = formatter;
        }

        public abstract void Print();
    }
}
