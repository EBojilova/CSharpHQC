namespace Phonebook
{
    using System;

    internal class PhonebookMain
    {
        private static readonly CommandManager CommandManager = new CommandManager();

        private static void Main()
        {
            string data;

            while ((data = Console.ReadLine()) != "End")
            {
                CommandManager.Output.Clear();
                CommandManager.ProceedCommands(data);
                Console.Write(CommandManager.Output);
            }

            ////Console.Write(CommandManager.Output());
        }
    }
}