namespace VechicleParkSystem
{
    using System;

    using VechicleParkSystem.Execution;
    using VechicleParkSystem.Interfaces;

    internal class Engine : IEngine
    {
        private readonly CommandExecuter executor;

        private readonly IUserInterface userIO;

        public Engine()
            : this(new CommandExecuter(), new ConsoleIo())
        {
        }

        private Engine(CommandExecuter executor, IUserInterface userIo)
        {
            this.executor = executor;
            this.userIO = userIo;
        }

        public void Run()
        {
            string commandLine;
            while ((commandLine = this.userIO.ReadLine()) != "End")
            {
                commandLine = commandLine.Trim();
                if (string.IsNullOrEmpty(commandLine))
                {
                    continue;
                }

                try
                {
                    var command = new Command(commandLine);
                    var commandResult = this.executor.CommandExecute(command);
                    this.userIO.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    this.userIO.WriteLine(ex.Message);
                }
            }
        }
    }
}