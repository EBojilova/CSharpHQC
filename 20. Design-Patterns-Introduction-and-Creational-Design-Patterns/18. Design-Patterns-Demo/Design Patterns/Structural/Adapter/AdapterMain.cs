namespace Adapter
{
    internal class AdapterMain
    {
        internal static void Main(string[] args)
        {
            ICompound water = new RichCompound("Water");
            ProcessCompound(water);

            ICompound benzene = new RichCompound("Benzene");
            ProcessCompound(benzene);

            ICompound ethanol = new RichCompound("Ethanol");
            ProcessCompound(ethanol);
        }

        /// <summary>
        /// Imame daden tozi klas, koito ni e daden i priema ICompaund. Ne mojem da promeniame ChemicalDatabank
        /// daimplementira ICompaund i da pechata s Display. Zatova pravim RichCompaund, koito implementira
        /// ICompaund i ima metod Display.
        /// </summary>
        /// <param name="compound"></param>
        internal static void ProcessCompound(ICompound compound)
        {
            // Process something
            compound.Display();

            // More processing...
        }
    }
}
