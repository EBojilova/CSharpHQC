namespace buhtig.Core
{
    using System;
    using System.IO;

    using IssueTracker.Core;
    using IssueTracker.Interfaces;

    public class Engine : IEngine
    {
       

        public Engine(IDispatcher dispatcher, IUserInterface userInterface)
        {
            this.Dispatcher = dispatcher;
            this.UserInterface = userInterface;
        }

        public Engine()
            : this(new Dispatcher(), new ConsoleUserInterface())
        {
        }

        public IDispatcher Dispatcher { get; }

        public IUserInterface UserInterface { get; }

        public void Run()
        {
            using (var reader = new StreamReader("../../URLs/002.txt"))
            {
                while (true)
                {
                    //var url = this.UserInterface.ReadLine();
                    var url = reader.ReadLine();
                    if (url != null)
                    {
                        break;
                    }
                    url = url.Trim();
                    if (string.IsNullOrEmpty(url))
                    {
                        try
                        {
                            var ep = new Endpoint(url);
                            var viewResult = this.Dispatcher.DispatchAction(ep);
                            this.UserInterface.WriteLine(viewResult);
                        }
                        catch (Exception ex)
                        {
                            this.UserInterface.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
    }
}