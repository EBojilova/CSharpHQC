namespace _01.ReformatCode
{
    using System.Text;

    internal static class Messages
    {
        internal static readonly StringBuilder Output = new StringBuilder();

        public static void PrintEventAdded()
        {
            Output.Append("Event added\n");
        }

        public static void PrintEventDeleted(int x)
        {
            if (x == 0)
            {
                PrintNoEventsFound();
            }
            else
            {
                Output.AppendFormat("{0} Events deleted\n", x);
            }
        }

        public static void PrintNoEventsFound()
        {
            Output.Append("No Events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Output.Append(eventToPrint + "\n");
            }
        }
    }
}