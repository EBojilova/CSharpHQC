namespace Prototype
{
    using System.Collections.Generic;

    using Prototype.Colours;

    /// <summary>
    /// Prototype manager
    /// </summary>
    internal class ColorManager
    {
        private readonly Dictionary<string, ColorPrototype> colors = new Dictionary<string, ColorPrototype>();

        // Indexer
        public ColorPrototype this[string key]
        {
            get
            {
                return this.colors[key];
            }

            set
            {
                this.colors.Add(key, value);
            }
        }
    }
}